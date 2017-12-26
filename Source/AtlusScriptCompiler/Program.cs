﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AtlusScriptLib.Common.Logging;
using AtlusScriptLib.Common.Registry;
using AtlusScriptLib.Common.Text.Encodings;
using AtlusScriptLib.Common.Text;
using AtlusScriptLib.FlowScriptLanguage;
using AtlusScriptLib.FlowScriptLanguage.BinaryModel;
using AtlusScriptLib.FlowScriptLanguage.Compiler;
using AtlusScriptLib.FlowScriptLanguage.Decompiler;
using AtlusScriptLib.FlowScriptLanguage.Disassembler;
using AtlusScriptLib.MessageScriptLanguage;
using AtlusScriptLib.MessageScriptLanguage.Compiler;
using AtlusScriptLib.MessageScriptLanguage.Decompiler;

namespace AtlusScriptCompiler
{
    internal class Program
    {
        public static Version Version = Assembly.GetExecutingAssembly().GetName().Version;

        public static Logger Logger = new Logger(nameof(AtlusScriptCompiler));

        public static LogListener Listener = new ConsoleLogListener( true, LogLevel.Info | LogLevel.Warning | LogLevel.Error | LogLevel.Fatal );

        public static string InputFilePath;

        public static string OutputFilePath;

        public static bool IsActionAssigned;

        public static bool DoCompile;

        public static bool DoDecompile;

        public static bool DoDisassemble;

        public static InputFileFormat InputFileFormat;

        public static OutputFileFormat OutputFileFormat;

        public static MessageScriptTextEncoding MessageScriptTextEncoding;

        public static string LibraryName;

        public static bool LogTrace;

        public static bool FlowScriptEnableProcedureTracing;

        public static bool FlowScriptEnableProcedureCallTracing;

        public static bool FlowScriptEnableFunctionCallTracing;

        public static bool FlowScriptEnableStackCookie;

        private static void DisplayUsage()
        {
            Console.WriteLine( $"AtlusScriptCompiler {Version.Major}.{Version.Minor} by TGE (2017)" );
            Console.WriteLine( "" );
            Console.WriteLine( "Parameter overview:" );
            Console.WriteLine( "    General:" );
            Console.WriteLine( "        -In                     <path to file>      Provides an input file source to the compiler. If no input source is explicitly specified, " );
            Console.WriteLine( "                                                    the first argument will be assumed to be one." );
            Console.WriteLine( "        -InFormat               <format>            Specifies the input file source format. By default this is guessed by the file extension." );
            Console.WriteLine( "        -Out                    <path to file>      Provides an output file path to the compiler. If no output source is explicitly specified, " );
            Console.WriteLine( "                                                    the file will be output in the same folder as the source file under a different extension depending on the format used." );
            Console.WriteLine( "        -OutFormat              <format>            Specifies the binary output file format. See below for further info." );
            Console.WriteLine( "        -Compile                                    Instructs the compiler to compile the provided input file source." );
            Console.WriteLine( "        -Decompile                                  Instructs the compiler to decompile the provided input file source." );
            Console.WriteLine( "        -Disassemble                                Instructs the compiler to disassemble the provided input file source." );
            Console.WriteLine( "        -Library                <name>              Specifies the name of the library that should be used." );
            Console.WriteLine( "        -LogTrace                                   Outputs trace log messages to the console" );
            Console.WriteLine();
            Console.WriteLine( "    MessageScript:" );
            Console.WriteLine( "        -Encoding               <format>            Specifies the MessageScript binary output text encoding. See below for further info." );
            Console.WriteLine();
            Console.WriteLine( "    FlowScript:" );
            Console.WriteLine( "        -TraceProcedure                            Enables procedure tracing. Only applies to compiler." );
            Console.WriteLine( "        -TraceProcedureCalls                       Enables procedure call tracing. Only applies to compiler." );
            Console.WriteLine( "        -TraceFunctionCalls                        Enables function call tracing. Only applies to compiler." );
            Console.WriteLine( "        -StackCookie                               Enables stack cookie. Used for debugging stack corruptions." );
            Console.WriteLine( "" );
            Console.WriteLine( "Parameter detailed info:" );
            Console.WriteLine( "    MessageScript:" );
            Console.WriteLine( "        -OutFormat" );
            Console.WriteLine( "            V1              Used by Persona 3, 4, 5 PS4" );
            Console.WriteLine( "            V1BE            Used by Persona 5 PS3" );
            Console.WriteLine();
            Console.WriteLine( "        -Encoding" );
            Console.WriteLine( "            Below is a list of different available encodings." );
            Console.WriteLine( "            Note that ASCII characters don't really differ from the standard, so this mostly applies to special characters and japanese characters." );
            Console.WriteLine();
            Console.WriteLine( "            SJ                  Shift-Jis encoding (CP932). Used by Persona Q" );
            Console.WriteLine( "            P3                  Persona 3's custom encoding" );
            Console.WriteLine( "            P4                  Persona 4's custom encoding" );
            Console.WriteLine( "            P5                  Persona 5's custom encoding" );
            Console.WriteLine();
            Console.WriteLine( "        -Library" );
            Console.WriteLine( "            For MessageScripts the library definition registry is used for the compiler and decompiler to emit the proper [f] tags for each aliased function." );
            Console.WriteLine( "            If you don't use any aliased functions, you don't need to specify this, but if you do without specifying it, you'll get a compiler error." );
            Console.WriteLine( "            Not specifying a library definition registry means that the decompiler will not try to look up aliases for functions." );
            Console.WriteLine( "            Library registries can be found in the Library\\Registry directory" );
            Console.WriteLine();
            Console.WriteLine( "    FlowScript:" );
            Console.WriteLine( "        -OutFormat" );
            Console.WriteLine( "            V1              Used by Persona 3 and 4" );
            Console.WriteLine( "            V1BE            " );
            Console.WriteLine( "            V2              Used by Persona 4 Dancing All Night" );
            Console.WriteLine( "            V2BE            " );
            Console.WriteLine( "            V3              Used by Persona 5 PS4" );
            Console.WriteLine( "            V3BE            Used by Persona 5 PS3" );
            Console.WriteLine();
            Console.WriteLine( "        -Library" );
            Console.WriteLine( "            For FlowScripts the library definition registry is used for the decompiler to decompile binary scripts, but it is also used to generate documentation." );
            Console.WriteLine( "            Without a specified registry you cannot decompile scripts." );
            Console.WriteLine( "            Library registries can be found in the Library\\Registry directory" );
            Console.ReadKey();
        }

        public static void Main( string[] args )
        {
            if ( args.Length == 0 )
            {
                Logger.Error( "No arguments specified!" );
                DisplayUsage();
                return;
            }

            if ( !TryParseArguments( args ) )
            {
                Logger.Error( "Failed to parse arguments!" );
                DisplayUsage();
                return;
            }

            // set up log listener
            Listener.Subscribe( Logger );
            if ( LogTrace )
                Listener.Filter |= LogLevel.Trace;

            bool success;

            if ( DoCompile )
            {
                success = TryDoCompilation();
            }
            else if ( DoDecompile )
            {
                success = TryDoDecompilation();
            }
            else if ( DoDisassemble )
            {
                success = TryDoDisassembling();
            }
            else
            {
                Logger.Error( "No compilation, decompilation or disassemble instruction given!" );
                DisplayUsage();
                return;
            }

            if ( success )
                Logger.Info( "Task completed successfully!" );
            else
                Logger.Error( "One or more errors occured while executing task!" );

            Console.ForegroundColor = ConsoleColor.White;
        }

        private static bool TryParseArguments( string[] args )
        {
            for ( int i = 0; i < args.Length; i++ )
            {
                bool isLast = i + 1 == args.Length;

                switch ( args[i] )
                {
                    // General
                    case "-In":
                        if ( isLast )
                        {
                            Logger.Error( "Missing argument for -In parameter" );
                            return false;
                        }

                        InputFilePath = args[++i];
                        break;

                    case "-InFormat":
                        if ( isLast )
                        {
                            Logger.Error( "Missing argument for -InFormat parameter" );
                            return false;
                        }

                        if ( !Enum.TryParse( args[++i], true, out InputFileFormat ) )
                        {
                            Logger.Error( "Invalid input file format specified" );
                            return false;
                        }

                        break;

                    case "-Out":
                        if ( isLast )
                        {
                            Logger.Error( "Missing argument for -Out parameter" );
                            return false;
                        }

                        OutputFilePath = args[++i];
                        break;

                    case "-OutFormat":
                        if ( isLast )
                        {
                            Logger.Error( "Missing argument for -OutFormat parameter" );
                            return false;
                        }

                        if ( !Enum.TryParse( args[++i], true, out OutputFileFormat ) )
                        {
                            Logger.Error( "Invalid output file format specified" );
                            return false;
                        }

                        break;

                    case "-Compile":
                        if ( !IsActionAssigned )
                        {
                            IsActionAssigned = true;
                        }
                        else
                        {
                            Logger.Error( "Attempted to assign compilation action while another action is already assigned." );
                            return false;
                        }

                        DoCompile = true;
                        break;

                    case "-Decompile":
                        if ( !IsActionAssigned )
                        {
                            IsActionAssigned = true;
                        }
                        else
                        {
                            Logger.Error( "Attempted to assign decompilation action while another action is already assigned." );
                            return false;
                        }

                        DoDecompile = true;
                        break;

                    case "-Disassemble":
                        if ( !IsActionAssigned )
                        {
                            IsActionAssigned = true;
                        }
                        else
                        {
                            Logger.Error( "Attempted to assign disassembly action while another action is already assigned." );
                            return false;
                        }

                        DoDisassemble = true;
                        break;

                    case "-Library":
                        if ( isLast )
                        {
                            Logger.Error( "Missing argument for -Library parameter" );
                            return false;
                        }

                        LibraryName = args[ ++i ];
                        break;

                    case "-LogTrace":
                        LogTrace = true;
                        break;

                    // MessageScript
                    case "-Encoding":
                        if ( isLast )
                        {
                            Logger.Error( "Missing argument for -Encoding parameter" );
                            return false;
                        }

                        if ( !Enum.TryParse( args[++i], true, out MessageScriptTextEncoding ) )
                        {
                            Logger.Error( "Invalid output file encoding specified" );
                            return false;
                        }

                        Logger.Info( $"Using {MessageScriptTextEncoding} encoding" );
                        break;

                    case "-TraceProcedure":
                        FlowScriptEnableProcedureTracing = true;
                        break;

                    case "-TraceProcedureCalls":
                        FlowScriptEnableProcedureCallTracing = true;
                        break;

                    case "-TraceFunctionCalls":
                        FlowScriptEnableFunctionCallTracing = true;
                        break;

                    case "-StackCookie":
                        FlowScriptEnableStackCookie = true;
                        break;
                }
            }

            if ( InputFilePath == null )
            {
                InputFilePath = args[0];
            }

            if ( !File.Exists(InputFilePath) )
            {
                Logger.Error( $"Specified input file doesn't exist! ({InputFilePath})" );
                return false;
            }

            if ( InputFileFormat == InputFileFormat.None )
            {
                var extension = Path.GetExtension( InputFilePath );

                switch ( extension.ToLowerInvariant() )
                {
                    case ".bf":
                        InputFileFormat = InputFileFormat.FlowScriptBinary;
                        break;

                    case ".flow":
                        InputFileFormat = InputFileFormat.FlowScriptTextSource;
                        break;

                    case ".flowasm":
                        InputFileFormat = InputFileFormat.FlowScriptAssemblerSource;
                        break;

                    case ".bmd":
                        InputFileFormat = InputFileFormat.MessageScriptBinary;
                        break;

                    case ".msg":
                        InputFileFormat = InputFileFormat.MessageScriptTextSource;
                        break;

                    default:
                        Logger.Error( "Unable to detect input file format" );
                        return false;
                }
            }

            if ( OutputFilePath == null )
            {
                if ( DoCompile )
                {
                    switch ( InputFileFormat )
                    {
                        case InputFileFormat.FlowScriptTextSource:
                        case InputFileFormat.FlowScriptAssemblerSource:
                            OutputFilePath = InputFilePath + ".bf";
                            break;
                        case InputFileFormat.MessageScriptTextSource:
                            OutputFilePath = InputFilePath + ".bmd";
                            break;
                    }
                }
                else if ( DoDecompile )
                {
                    switch ( InputFileFormat )
                    {
                        case InputFileFormat.FlowScriptBinary:
                            OutputFilePath = InputFilePath + ".flow";
                            break;
                        case InputFileFormat.MessageScriptBinary:
                            OutputFilePath = InputFilePath + ".msg";
                            break;
                    }
                }
                else if ( DoDisassemble )
                {
                    switch ( InputFileFormat )
                    {
                        case InputFileFormat.FlowScriptBinary:
                            OutputFilePath = InputFilePath + ".flowasm";
                            break;
                    }
                }
            }

            Logger.Info( $"Output file path is set to {OutputFilePath}" );

            return true;
        }

        private static bool TryDoCompilation()
        {
            switch ( InputFileFormat )
            {
                case InputFileFormat.FlowScriptTextSource:
                case InputFileFormat.FlowScriptAssemblerSource:
                    return TryDoFlowScriptCompilation();

                case InputFileFormat.MessageScriptTextSource:
                    return TryDoMessageScriptCompilation();

                case InputFileFormat.FlowScriptBinary:
                case InputFileFormat.MessageScriptBinary:
                    Logger.Error( "Binary files can't be compiled again!" );
                    return false;

                default:
                    Logger.Error( "Invalid input file format!" );
                    return false;
            }
        }

        private static bool TryDoFlowScriptCompilation()
        {
            Logger.Info( "Compiling FlowScript..." );

            // Get format verson
            FlowScriptFormatVersion version;
            switch ( OutputFileFormat )
            {
                case OutputFileFormat.V1:
                    version = FlowScriptFormatVersion.Version1;
                    break;
                case OutputFileFormat.V1BE:
                    version = FlowScriptFormatVersion.Version1BigEndian;
                    break;
                case OutputFileFormat.V2:
                    version = FlowScriptFormatVersion.Version2;
                    break;
                case OutputFileFormat.V2BE:
                    version = FlowScriptFormatVersion.Version2BigEndian;
                    break;
                case OutputFileFormat.V3:
                    version = FlowScriptFormatVersion.Version3;
                    break;
                case OutputFileFormat.V3BE:
                    version = FlowScriptFormatVersion.Version3BigEndian;
                    break;
                default:
                    Logger.Error( "Invalid FlowScript file format specified" );
                    return false;
            }

            // Compile source
            var compiler = new FlowScriptCompiler( version );
            compiler.AddListener( Listener );
            compiler.Encoding = GetEncoding();
            compiler.EnableProcedureTracing = FlowScriptEnableProcedureTracing;
            compiler.EnableProcedureCallTracing = FlowScriptEnableProcedureCallTracing;
            compiler.EnableFunctionCallTracing = FlowScriptEnableFunctionCallTracing;
            compiler.EnableStackCookie = FlowScriptEnableStackCookie;

            if ( LibraryName != null )
            {
                var library = LibraryRegistryCache.GetLibraryRegistry( LibraryName );

                if ( library == null )
                {
                    Logger.Error( "Invalid library name specified" );
                    return false;
                }

                compiler.LibraryRegistry = library;
            }

            FlowScript flowScript;
            using ( var file = File.Open( InputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read ) )
            {
                if ( !compiler.TryCompile( file, out flowScript ) )
                {
                    Logger.Error( "One or more errors occured during compilation!" );
                    return false;
                }
            }
            
            // Write binary
            Logger.Info( "Writing binary to file..." );
            return TryPerformAction( "An error occured while saving the file.", () => flowScript.ToFile( OutputFilePath ) );
        }

        private static bool TryDoMessageScriptCompilation()
        {
            // Compile source
            Logger.Info( "Compiling MessageScript..." );

            MessageScriptFormatVersion version;

            if ( OutputFileFormat == OutputFileFormat.V1 )
            {
                version = MessageScriptFormatVersion.Version1;
            }
            else if ( OutputFileFormat == OutputFileFormat.V1BE )
            {
                version = MessageScriptFormatVersion.Version1BigEndian;
            }
            else
            {
                Logger.Error( "Invalid MessageScript file format" );
                return false;
            }

            var encoding = GetEncoding();
            var compiler = new MessageScriptCompiler( version, encoding );
            compiler.AddListener( Listener );

            if ( LibraryName != null )
            {
                var library = LibraryRegistryCache.GetLibraryRegistry( LibraryName );

                if ( library == null )
                {
                    Logger.Error( "Invalid library name specified" );
                    return false;
                }

                compiler.LibraryRegistry = library;
            }

            if ( !compiler.TryCompile( File.OpenText( InputFilePath ), out var script ) )
            {
                Logger.Error( "One or more errors occured during compilation!" );
                return false;
            }

            // Write binary
            Logger.Info( "Writing binary to file..." );
            if ( !TryPerformAction( "An error occured while saving the file.", () => script.ToFile( OutputFilePath ) ) )
                return false;

            return true;
        }

        private static bool TryDoDecompilation()
        {
            switch ( InputFileFormat )
            {
                case InputFileFormat.FlowScriptTextSource:
                case InputFileFormat.FlowScriptAssemblerSource:
                case InputFileFormat.MessageScriptTextSource:
                    Logger.Error( "Can't decompile a text source!" );
                    return false;

                case InputFileFormat.FlowScriptBinary:
                    return TryDoFlowScriptDecompilation();

                case InputFileFormat.MessageScriptBinary:
                    return TryDoMessageScriptDecompilation();

                default:
                    Logger.Error( "Invalid input file format!" );
                    return false;
            }
        }

        private static bool TryDoFlowScriptDecompilation()
        {
            // Load binary file
            Logger.Info( "Loading binary FlowScript file..." );
            FlowScript flowScript = null;
            var encoding = GetEncoding();

            if ( !TryPerformAction( "Failed to load flow script from file", () => flowScript = FlowScript.FromFile( InputFilePath, encoding ) ) )
                return false;

            Logger.Info( "Decompiling FlowScript..." );

            var decompiler = new FlowScriptDecompiler();
            decompiler.AddListener( Listener );

            if ( LibraryName != null )
            {
                var library = LibraryRegistryCache.GetLibraryRegistry( LibraryName );

                if ( library == null )
                {
                    Logger.Error( "Invalid library name specified" );
                    return false;
                }

                decompiler.LibraryRegistry = library;
            }

            if ( !decompiler.TryDecompile( flowScript, OutputFilePath ) )
            {
                Logger.Error( "Failed to decompile FlowScript" );
                return false;
            }

            return true;
        }

        private static bool TryDoMessageScriptDecompilation()
        {
            // load binary file
            Logger.Info( "Loading binary MessageScript file..." );
            MessageScript script = null;
            var encoding = GetEncoding();

            if ( !TryPerformAction( "Failed to load message script from file.", () => script = MessageScript.FromFile( InputFilePath, encoding ) ) )
                return false;

            Logger.Info( "Decompiling MessageScript..." );

            if ( !TryPerformAction( "Failed to decompile message script to file.", () =>
            {
                using ( var decompiler = new MessageScriptDecompiler( new FileTextWriter( OutputFilePath ) ) )
                {
                    if ( LibraryName != null )
                    {
                        var library = LibraryRegistryCache.GetLibraryRegistry( LibraryName );

                        if ( library == null )
                        {
                            Logger.Error( "Invalid library name specified" );
                        }

                        decompiler.LibraryRegistry = library;
                    }

                    decompiler.Decompile( script );
                }
            } ) )
            {
                return false;
            }

            return true;
        }

        private static bool TryDoDisassembling()
        {
            switch ( InputFileFormat )
            {
                case InputFileFormat.FlowScriptTextSource:
                case InputFileFormat.FlowScriptAssemblerSource:
                case InputFileFormat.MessageScriptTextSource:
                    Logger.Error( "Can't disassemble a text source!" );
                    return false;

                case InputFileFormat.FlowScriptBinary:
                    return TryDoFlowScriptDisassembly();

                case InputFileFormat.MessageScriptBinary:
                    Logger.Info( "Error. Disassembling message scripts is not supported." );
                    return false;

                default:
                    Logger.Error( "Invalid input file format!" );
                    return false;
            }
        }

        private static bool TryDoFlowScriptDisassembly()
        {
            // load binary file
            Logger.Info( "Loading binary FlowScript file..." );

            
            FlowScriptBinary script = null;

            if ( !TryPerformAction( "Failed to load flow script from file.", () =>
            {
                script = FlowScriptBinary.FromFile( InputFilePath );
            } ) )
            {
                return false;
            }

            Logger.Info( "Disassembling FlowScript..." );
            if ( !TryPerformAction( "Failed to disassemble flow script to file.", () =>
            {
                var disassembler = new FlowScriptBinaryDisassembler( OutputFilePath );
                disassembler.Disassemble( script );
            } ) )
            {
                return false;
            }

            return true;
        }

        private static bool TryPerformAction( string errorMessage, Action action )
        {
#if !DEBUG
            try
            {
#endif
                action();
#if !DEBUG
            }
            catch ( Exception e )
            {
                LogException( errorMessage, e );
                return false;
            }
#endif

            return true;
        }

        private static Encoding GetEncoding( )
        {
            Encoding encoding = null;

            if ( MessageScriptTextEncoding == MessageScriptTextEncoding.SJ )
            {
                encoding = Encoding.GetEncoding( 932 );
            }
            else if ( MessageScriptTextEncoding == MessageScriptTextEncoding.P3 )
            {
                encoding = new Persona3Encoding();
            }
            else if ( MessageScriptTextEncoding == MessageScriptTextEncoding.P4 )
            {
                encoding = new Persona4Encoding();
            }
            else if ( MessageScriptTextEncoding == MessageScriptTextEncoding.P5 )
            {
                encoding = new Persona5Encoding();
            }

            return encoding;
        }

        private static void LogException( string message, Exception e )
        {
            Logger.Error( message );
            Logger.Debug( "Exception info:" );
            Logger.Debug( $"{e.Message}" );
            Logger.Debug( "Stacktrace:" );
            Logger.Debug( $"{e.StackTrace}" );
        }
    }

    public enum InputFileFormat
    {
        None,
        FlowScriptBinary,
        FlowScriptTextSource,
        FlowScriptAssemblerSource,
        MessageScriptBinary,
        MessageScriptTextSource,
    }

    public enum OutputFileFormat
    {
        None,
        V1,
        V1BE,
        V2,
        V2BE,
        V3,
        V3BE
    }

    public enum MessageScriptTextEncoding
    {
        None,
        SJ,
        P3,
        P4,
        P5
    }
}
