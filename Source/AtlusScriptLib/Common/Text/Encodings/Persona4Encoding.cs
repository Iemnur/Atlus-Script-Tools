﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlusScriptLib.Common.Text.Encodings
{
    public class Persona4Encoding : AtlusEncoding
    {
        protected override char[] CharTable => sCharTable;

        /// <summary>
        /// All credit goes to Senketsu (鮮尻) and tomas_xc for mapping out this table.
        /// </summary>
        private static char[] sCharTable = new char[]
        {
            (char)00, (char)01, (char)02, (char)03, (char)04, (char)05, (char)06, (char)07, (char)08, (char)09, (char)10, (char)11, (char)12, (char)13, (char)14, (char)15,
            (char)16, (char)17, (char)18, (char)19, (char)20, (char)21, (char)22, (char)23, (char)24, (char)25, (char)26, (char)27, (char)28, (char)29, (char)30, (char)31,
            ' ', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ':', ';', '<', '=', '>', '?',
            '@', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O',
            'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '[', '\\', ']', '^', '_',
            '`', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o',
            'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '{', '|', '}', '~', 'ぁ',
            'あ', 'ぃ', 'い', 'ぅ', 'う', 'ぇ', 'え', 'ぉ', 'お', 'か', 'が', 'き', 'ぎ', 'く', 'ぐ', 'け',
            'げ', 'こ', 'ご', 'さ', 'ざ', 'し', 'じ', 'す', 'ず', 'せ', 'ぜ', 'そ', 'ぞ', 'た', 'だ', 'ち',
            'ぢ', 'っ', 'つ', 'づ', 'て', 'で', 'と', 'ど', 'な', 'に', 'ぬ', 'ね', 'の', 'は', 'ば', 'ぱ',
            'ひ', 'び', 'ぴ', 'ふ', 'ぶ', 'ぷ', 'へ', 'べ', 'ぺ', 'ほ', 'ぼ', 'ぽ', 'ま', 'み', 'む', 'め',
            'も', 'ゃ', 'や', 'ゅ', 'ゆ', 'ょ', 'よ', 'ら', 'り', 'る', 'れ', 'ろ', 'ゎ', 'わ', 'ゐ', 'ゑ',
            'を', 'ん', 'ァ', 'ア', 'ィ', 'イ', 'ゥ', 'ウ', 'ェ', 'エ', 'ォ', 'オ', 'カ', 'ガ', 'キ', 'ギ',
            'ク', 'グ', 'ケ', 'ゲ', 'コ', 'ゴ', 'サ', 'ザ', 'シ', 'ジ', 'ス', 'ズ', 'セ', 'ゼ', 'ソ', 'ゾ',
            'タ', 'ダ', 'チ', 'ヂ', 'ッ', 'ツ', 'ヅ', 'テ', 'デ', 'ト', 'ド', 'ナ', 'ニ', 'ヌ', 'ネ', 'ノ',
            'ハ', 'バ', 'パ', 'ヒ', 'ビ', 'ピ', 'フ', 'ブ', 'プ', 'ヘ', 'ベ', 'ペ', 'ホ', 'ボ', 'ポ', 'マ',
            'ミ', 'ム', 'メ', 'モ', 'ャ', 'ヤ', 'ュ', 'ユ', 'ョ', 'ヨ', 'ラ', 'リ', 'ル', 'レ', 'ロ', 'ヮ',
            'ワ', 'ヰ', 'ヱ', 'ヲ', 'ン', 'ヴ', 'ヵ', 'ヶ', '、', '。', '・', '゛', '゜', '´', '｀', '¨',
            'ヽ', 'ヾ', 'ゝ', 'ゞ', '〃', '❤', '々', ' ', '〇', 'ー', '‐', '～', '∥', '…', '‥', '“',
            '〔', '〕', '〈', '〉', '《', '》', '「', '」', '『', '』', '【', '】', '－', '±', '×', '・',
            '÷', '≠', '≦', '≧', '∞', '∴', '♂', '♀', '°', '′', '″', '℃', '￥', '￠', '￡', '§',
            '☆', '★', '○', '●', '◎', '◇', '◆', '□', '■', '△', '▲', '▽', '▼', '※', '〒', '→',
            '←', '↑', '↓', '〓', 'Α', 'Β', 'Γ', 'Δ', 'Ε', 'Ζ', 'Η', 'Θ', 'Ι', 'Κ', 'Λ', 'Μ',
            'Ν', 'Ξ', 'Ο', 'Π', 'Ρ', 'Σ', 'Τ', 'Υ', 'Φ', 'Χ', 'Ψ', 'Ω', 'α', 'β', 'γ', 'δ',
            'ε', 'ζ', 'η', 'θ', 'ι', 'κ', 'λ', 'μ', 'ν', 'ξ', 'ο', 'π', 'ρ', 'σ', 'τ', 'υ',
            'φ', 'χ', 'ψ', 'ω', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К',
            'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ',
            'Ы', 'Ь', 'Э', 'Ю', 'Я', 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й',
            'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ',
            'ъ', 'ы', 'ь', 'э', 'ю', 'я', '亜', '唖', '娃', '阿', '哀', '愛', '挨', '姶', '逢', '葵',
            '茜', '穐', '悪', '握', '渥', '旭', '葦', '芦', '鯵', '梓', '圧', '斡', '扱', '宛', '姐', '虻',
            '飴', '絢', '綾', '鮎', '或', '粟', '袷', '安', '庵', '按', '暗', '案', '闇', '鞍', '杏', '以',
            '伊', '位', '依', '偉', '囲', '夷', '委', '威', '尉', '惟', '意', '慰', '易', '椅', '為', '畏',
            '異', '移', '維', '緯', '胃', '萎', '衣', '謂', '違', '遺', '医', '井', '亥', '域', '育', '郁',
            '磯', '一', '壱', '溢', '逸', '稲', '茨', '芋', '鰯', '允', '印', '咽', '員', '因', '姻', '引',
            '飲', '淫', '胤', '蔭', '院', '陰', '隠', '韻', '吋', '右', '宇', '烏', '羽', '迂', '雨', '卯',
            '鵜', '窺', '丑', '碓', '臼', '渦', '嘘', '唄', '欝', '蔚', '鰻', '姥', '厩', '浦', '瓜', '閏',
            '噂', '云', '運', '雲', '荏', '餌', '叡', '営', '嬰', '影', '映', '曳', '栄', '永', '泳', '洩',
            '瑛', '盈', '穎', '頴', '英', '衛', '詠', '鋭', '液', '疫', '益', '駅', '悦', '謁', '越', '閲',
            '榎', '厭', '円', '園', '堰', '奄', '宴', '延', '怨', '掩', '援', '沿', '演', '炎', '焔', '煙',
            '燕', '猿', '縁', '艶', '苑', '薗', '遠', '鉛', '鴛', '塩', '於', '汚', '甥', '凹', '央', '奥',
            '往', '応', '押', '旺', '横', '欧', '殴', '王', '翁', '襖', '鴬', '鴎', '黄', '岡', '沖', '荻',
            '億', '屋', '憶', '臆', '桶', '牡', '乙', '俺', '卸', '恩', '温', '穏', '音', '下', '化', '仮',
            '何', '伽', '価', '佳', '加', '可', '嘉', '夏', '嫁', '家', '寡', '科', '暇', '果', '架', '歌',
            '河', '火', '珂', '禍', '禾', '稼', '箇', '花', '苛', '茄', '荷', '華', '菓', '蝦', '課', '嘩',
            '貨', '迦', '過', '霞', '蚊', '俄', '峨', '我', '牙', '画', '臥', '芽', '蛾', '賀', '雅', '餓',
            '駕', '介', '会', '解', '回', '塊', '壊', '廻', '快', '怪', '悔', '恢', '懐', '戒', '拐', '改',
            '魁', '晦', '械', '海', '灰', '界', '皆', '絵', '芥', '蟹', '開', '階', '貝', '凱', '劾', '外',
            '咳', '害', '崖', '慨', '概', '涯', '碍', '蓋', '街', '該', '鎧', '骸', '浬', '馨', '蛙', '垣',
            '柿', '蛎', '鈎', '劃', '嚇', '各', '廓', '拡', '撹', '格', '核', '殻', '獲', '確', '穫', '覚',
            '角', '赫', '較', '郭', '閣', '隔', '革', '学', '岳', '楽', '額', '顎', '掛', '笠', '樫', '橿',
            '梶', '鰍', '潟', '割', '喝', '恰', '括', '活', '渇', '滑', '葛', '褐', '轄', '且', '鰹', '叶',
            '椛', '樺', '鞄', '株', '兜', '竃', '蒲', '釜', '鎌', '噛', '鴨', '栢', '茅', '萱', '粥', '刈',
            '苅', '瓦', '乾', '侃', '冠', '寒', '刊', '勘', '勧', '巻', '喚', '堪', '姦', '完', '官', '寛',
            '干', '幹', '患', '感', '慣', '憾', '換', '敢', '柑', '桓', '棺', '款', '歓', '汗', '漢', '澗',
            '潅', '環', '甘', '監', '看', '竿', '管', '簡', '緩', '缶', '翰', '肝', '艦', '莞', '観', '諌',
            '貫', '還', '鑑', '間', '閑', '関', '陥', '韓', '館', '舘', '丸', '含', '岸', '巌', '玩', '癌',
            '眼', '岩', '翫', '贋', '雁', '頑', '顔', '願', '企', '伎', '危', '喜', '器', '基', '奇', '嬉',
            '寄', '岐', '希', '幾', '忌', '揮', '机', '旗', '既', '期', '棋', '棄', '機', '帰', '毅', '気',
            '汽', '畿', '祈', '季', '稀', '紀', '徽', '規', '記', '貴', '起', '軌', '輝', '飢', '騎', '鬼',
            '亀', '偽', '儀', '妓', '宜', '戯', '技', '擬', '欺', '犠', '疑', '祇', '義', '蟻', '誼', '議',
            '掬', '菊', '鞠', '吉', '吃', '喫', '桔', '橘', '詰', '砧', '杵', '黍', '却', '客', '脚', '虐',
            '逆', '丘', '久', '仇', '休', '及', '吸', '宮', '弓', '急', '救', '朽', '求', '汲', '泣', '灸',
            '球', '究', '窮', '笈', '級', '糾', '給', '旧', '牛', '去', '居', '巨', '拒', '拠', '挙', '渠',
            '虚', '許', '距', '鋸', '漁', '禦', '魚', '亨', '享', '京', '供', '侠', '僑', '兇', '競', '共',
            '凶', '協', '匡', '卿', '叫', '喬', '境', '峡', '強', '彊', '怯', '恐', '恭', '挟', '教', '橋',
            '況', '狂', '狭', '矯', '胸', '脅', '興', '蕎', '郷', '鏡', '響', '饗', '驚', '仰', '凝', '尭',
            '暁', '業', '局', '曲', '極', '玉', '桐', '粁', '僅', '勤', '均', '巾', '錦', '斤', '欣', '欽',
            '琴', '禁', '禽', '筋', '緊', '芹', '菌', '衿', '襟', '謹', '近', '金', '吟', '銀', '九', '倶',
            '句', '区', '狗', '玖', '矩', '苦', '躯', '駆', '駈', '駒', '具', '愚', '虞', '喰', '空', '偶',
            '寓', '遇', '隅', '串', '櫛', '釧', '屑', '屈', '掘', '窟', '沓', '靴', '轡', '窪', '熊', '隈',
            '粂', '栗', '繰', '桑', '鍬', '勲', '君', '薫', '訓', '群', '軍', '郡', '卦', '袈', '祁', '係',
            '傾', '刑', '兄', '啓', '圭', '珪', '型', '契', '形', '径', '恵', '慶', '慧', '憩', '掲', '携',
            '敬', '景', '桂', '渓', '畦', '稽', '系', '経', '継', '繋', '罫', '茎', '荊', '蛍', '計', '詣',
            '警', '軽', '頚', '鶏', '芸', '迎', '鯨', '劇', '戟', '撃', '激', '隙', '桁', '傑', '欠', '決',
            '潔', '穴', '結', '血', '訣', '月', '件', '倹', '倦', '健', '兼', '券', '剣', '喧', '圏', '堅',
            '嫌', '建', '憲', '懸', '拳', '捲', '検', '権', '牽', '犬', '献', '研', '硯', '絹', '県', '肩',
            '見', '謙', '賢', '軒', '遣', '鍵', '険', '顕', '験', '鹸', '元', '原', '厳', '幻', '弦', '減',
            '源', '玄', '現', '絃', '舷', '言', '諺', '限', '乎', '個', '古', '呼', '固', '姑', '孤', '己',
            '庫', '弧', '戸', '故', '枯', '湖', '狐', '糊', '袴', '股', '胡', '菰', '虎', '誇', '跨', '鈷',
            '雇', '顧', '鼓', '五', '互', '伍', '午', '呉', '吾', '娯', '後', '御', '悟', '梧', '檎', '瑚',
            '碁', '語', '誤', '護', '醐', '乞', '鯉', '交', '佼', '侯', '候', '倖', '光', '公', '功', '効',
            '勾', '厚', '口', '向', '后', '喉', '坑', '垢', '好', '孔', '孝', '宏', '工', '巧', '巷', '幸',
            '広', '庚', '康', '弘', '恒', '慌', '抗', '拘', '控', '攻', '昂', '晃', '更', '杭', '校', '梗',
            '構', '江', '洪', '浩', '港', '溝', '甲', '皇', '硬', '稿', '糠', '紅', '紘', '絞', '綱', '耕',
            '考', '肯', '肱', '腔', '膏', '航', '荒', '行', '衡', '講', '貢', '購', '郊', '酵', '鉱', '砿',
            '鋼', '閤', '降', '項', '香', '高', '鴻', '剛', '劫', '号', '合', '壕', '拷', '濠', '豪', '轟',
            '麹', '克', '刻', '告', '国', '穀', '酷', '鵠', '黒', '獄', '漉', '腰', '甑', '忽', '惚', '骨',
            '狛', '込', '此', '頃', '今', '困', '坤', '墾', '婚', '恨', '懇', '昏', '昆', '根', '梱', '混',
            '痕', '紺', '艮', '魂', '些', '佐', '叉', '唆', '嵯', '左', '差', '査', '沙', '瑳', '砂', '詐',
            '鎖', '裟', '坐', '座', '挫', '債', '催', '再', '最', '哉', '塞', '妻', '宰', '彩', '才', '採',
            '栽', '歳', '済', '災', '采', '犀', '砕', '砦', '祭', '斎', '細', '菜', '裁', '載', '際', '剤',
            '在', '材', '罪', '財', '冴', '坂', '阪', '堺', '榊', '肴', '咲', '崎', '埼', '碕', '鷺', '作',
            '削', '咋', '搾', '昨', '朔', '柵', '窄', '策', '索', '錯', '桜', '鮭', '笹', '匙', '冊', '刷',
            '察', '拶', '撮', '擦', '札', '殺', '薩', '雑', '皐', '鯖', '捌', '錆', '鮫', '皿', '晒', '三',
            '傘', '参', '山', '惨', '撒', '散', '桟', '燦', '珊', '産', '算', '纂', '蚕', '讃', '賛', '酸',
            '餐', '斬', '暫', '残', '仕', '仔', '伺', '使', '刺', '司', '史', '嗣', '四', '士', '始', '姉',
            '姿', '子', '屍', '市', '師', '志', '思', '指', '支', '孜', '斯', '施', '旨', '枝', '止', '死',
            '氏', '獅', '祉', '私', '糸', '紙', '紫', '肢', '脂', '至', '視', '詞', '詩', '試', '誌', '諮',
            '資', '賜', '雌', '飼', '歯', '事', '似', '侍', '児', '字', '寺', '慈', '持', '時', '次', '滋',
            '治', '爾', '璽', '痔', '磁', '示', '而', '耳', '自', '蒔', '辞', '汐', '鹿', '式', '識', '鴫',
            '竺', '軸', '宍', '雫', '七', '叱', '執', '失', '嫉', '室', '悉', '湿', '漆', '疾', '質', '実',
            '蔀', '篠', '偲', '柴', '芝', '屡', '蕊', '縞', '舎', '写', '射', '捨', '赦', '斜', '煮', '社',
            '紗', '者', '謝', '車', '遮', '蛇', '邪', '借', '勺', '尺', '杓', '灼', '爵', '酌', '釈', '錫',
            '若', '寂', '弱', '惹', '主', '取', '守', '手', '朱', '殊', '狩', '珠', '種', '腫', '趣', '酒',
            '首', '儒', '受', '呪', '寿', '授', '樹', '綬', '需', '囚', '収', '周', '宗', '就', '州', '修',
            '愁', '拾', '洲', '秀', '秋', '終', '繍', '習', '臭', '舟', '蒐', '衆', '襲', '讐', '蹴', '輯',
            '週', '酋', '酬', '集', '醜', '什', '住', '充', '十', '従', '戎', '柔', '汁', '渋', '獣', '縦',
            '重', '銃', '叔', '夙', '宿', '淑', '祝', '縮', '粛', '塾', '熟', '出', '術', '述', '俊', '峻',
            '春', '瞬', '竣', '舜', '駿', '准', '循', '旬', '楯', '殉', '淳', '準', '潤', '盾', '純', '巡',
            '遵', '醇', '順', '処', '初', '所', '暑', '曙', '渚', '庶', '緒', '署', '書', '薯', '藷', '諸',
            '助', '叙', '女', '序', '徐', '恕', '鋤', '除', '傷', '償', '勝', '匠', '升', '召', '哨', '商',
            '唱', '嘗', '奨', '妾', '娼', '宵', '将', '小', '少', '尚', '庄', '床', '廠', '彰', '承', '抄',
            '招', '掌', '捷', '昇', '昌', '昭', '晶', '松', '梢', '樟', '樵', '沼', '消', '渉', '湘', '焼',
            '焦', '照', '症', '省', '硝', '礁', '祥', '称', '章', '笑', '粧', '紹', '肖', '菖', '蒋', '蕉',
            '衝', '裳', '訟', '証', '詔', '詳', '象', '賞', '醤', '鉦', '鍾', '鐘', '障', '鞘', '上', '丈',
            '丞', '乗', '冗', '剰', '城', '場', '壌', '嬢', '常', '情', '擾', '条', '杖', '浄', '状', '畳',
            '穣', '蒸', '譲', '醸', '錠', '嘱', '埴', '飾', '拭', '植', '殖', '燭', '織', '職', '色', '触',
            '食', '蝕', '辱', '尻', '伸', '信', '侵', '唇', '娠', '寝', '審', '心', '慎', '振', '新', '晋',
            '森', '榛', '浸', '深', '申', '疹', '真', '神', '秦', '紳', '臣', '芯', '薪', '親', '診', '身',
            '辛', '進', '針', '震', '人', '仁', '刃', '塵', '壬', '尋', '甚', '尽', '腎', '訊', '迅', '陣',
            '靭', '笥', '諏', '須', '酢', '図', '厨', '逗', '吹', '垂', '帥', '推', '水', '炊', '睡', '粋',
            '翠', '衰', '遂', '酔', '錐', '錘', '随', '瑞', '髄', '崇', '嵩', '数', '枢', '趨', '雛', '据',
            '杉', '椙', '菅', '頗', '雀', '裾', '澄', '摺', '寸', '世', '瀬', '畝', '是', '凄', '制', '勢',
            '姓', '征', '性', '成', '政', '整', '星', '晴', '棲', '栖', '正', '清', '牲', '生', '盛', '精',
            '聖', '声', '製', '西', '誠', '誓', '請', '逝', '醒', '青', '静', '斉', '税', '脆', '隻', '席',
            '惜', '戚', '斥', '昔', '析', '石', '積', '籍', '績', '脊', '責', '赤', '跡', '蹟', '碩', '切',
            '拙', '接', '摂', '折', '設', '窃', '節', '説', '雪', '絶', '舌', '蝉', '仙', '先', '千', '占',
            '宣', '専', '尖', '川', '戦', '扇', '撰', '栓', '栴', '泉', '浅', '洗', '染', '潜', '煎', '煽',
            '旋', '穿', '箭', '線', '繊', '羨', '腺', '舛', '船', '薦', '詮', '賎', '践', '選', '遷', '銭',
            '銑', '閃', '鮮', '前', '善', '漸', '然', '全', '禅', '繕', '膳', '糎', '噌', '塑', '岨', '措',
            '曾', '曽', '楚', '狙', '疏', '疎', '礎', '祖', '租', '粗', '素', '組', '蘇', '訴', '阻', '遡',
            '鼠', '僧', '創', '双', '叢', '倉', '喪', '壮', '奏', '爽', '宋', '層', '匝', '惣', '想', '捜',
            '掃', '挿', '掻', '操', '早', '曹', '巣', '槍', '槽', '漕', '燥', '争', '痩', '相', '窓', '糟',
            '総', '綜', '聡', '草', '荘', '葬', '蒼', '藻', '装', '走', '送', '遭', '鎗', '霜', '騒', '像',
            '増', '憎', '臓', '蔵', '贈', '造', '促', '側', '則', '即', '息', '捉', '束', '測', '足', '速',
            '俗', '属', '賊', '族', '続', '卒', '袖', '其', '揃', '存', '孫', '尊', '損', '村', '遜', '他',
            '多', '太', '汰', '詑', '唾', '堕', '妥', '惰', '打', '柁', '舵', '楕', '陀', '駄', '騨', '体',
            '堆', '対', '耐', '岱', '帯', '待', '怠', '態', '戴', '替', '泰', '滞', '胎', '腿', '苔', '袋',
            '貸', '退', '逮', '隊', '黛', '鯛', '代', '台', '大', '第', '醍', '題', '鷹', '滝', '瀧', '卓',
            '啄', '宅', '托', '択', '拓', '沢', '濯', '琢', '託', '鐸', '濁', '諾', '茸', '凧', '蛸', '只',
            '叩', '但', '達', '辰', '奪', '脱', '巽', '竪', '辿', '棚', '谷', '狸', '鱈', '樽', '誰', '丹',
            '単', '嘆', '坦', '担', '探', '旦', '歎', '淡', '湛', '炭', '短', '端', '箪', '綻', '耽', '胆',
            '蛋', '誕', '鍛', '団', '壇', '弾', '断', '暖', '檀', '段', '男', '談', '値', '知', '地', '弛',
            '恥', '智', '池', '痴', '稚', '置', '致', '蜘', '遅', '馳', '築', '畜', '竹', '筑', '蓄', '逐',
            '秩', '窒', '茶', '嫡', '着', '中', '仲', '宙', '忠', '抽', '昼', '柱', '注', '虫', '衷', '註',
            '酎', '鋳', '駐', '樗', '瀦', '猪', '苧', '著', '貯', '丁', '兆', '凋', '喋', '寵', '帖', '帳',
            '庁', '弔', '張', '彫', '徴', '懲', '挑', '暢', '朝', '潮', '牒', '町', '眺', '聴', '脹', '腸',
            '蝶', '調', '諜', '超', '跳', '銚', '長', '頂', '鳥', '勅', '捗', '直', '朕', '沈', '珍', '賃',
            '鎮', '陳', '津', '墜', '椎', '槌', '追', '鎚', '痛', '通', '塚', '栂', '掴', '槻', '佃', '漬',
            '柘', '辻', '蔦', '綴', '鍔', '椿', '潰', '坪', '壷', '嬬', '紬', '爪', '吊', '釣', '鶴', '亭',
            '低', '停', '偵', '剃', '貞', '呈', '堤', '定', '帝', '底', '庭', '廷', '弟', '悌', '抵', '挺',
            '提', '梯', '汀', '碇', '禎', '程', '締', '艇', '訂', '諦', '蹄', '逓', '邸', '鄭', '釘', '鼎',
            '泥', '摘', '擢', '敵', '滴', '的', '笛', '適', '鏑', '溺', '哲', '徹', '撤', '轍', '迭', '鉄',
            '典', '填', '天', '展', '店', '添', '纏', '甜', '貼', '転', '顛', '点', '伝', '殿', '澱', '田',
            '電', '兎', '吐', '堵', '塗', '妬', '屠', '徒', '斗', '杜', '渡', '登', '菟', '賭', '途', '都',
            '鍍', '砥', '砺', '努', '度', '土', '奴', '怒', '倒', '党', '冬', '凍', '刀', '唐', '塔', '塘',
            '套', '宕', '島', '嶋', '悼', '投', '搭', '東', '桃', '梼', '棟', '盗', '淘', '湯', '涛', '灯',
            '燈', '当', '痘', '祷', '等', '答', '筒', '糖', '統', '到', '董', '蕩', '藤', '討', '謄', '豆',
            '踏', '逃', '透', '鐙', '陶', '頭', '騰', '闘', '働', '動', '同', '堂', '導', '憧', '撞', '洞',
            '瞳', '童', '胴', '萄', '道', '銅', '峠', '鴇', '匿', '得', '徳', '涜', '特', '督', '禿', '篤',
            '毒', '独', '読', '栃', '橡', '凸', '突', '椴', '届', '鳶', '苫', '寅', '酉', '瀞', '噸', '屯',
            '惇', '敦', '沌', '豚', '遁', '頓', '呑', '曇', '鈍', '奈', '那', '内', '乍', '凪', '薙', '謎',
            '灘', '捺', '鍋', '楢', '馴', '縄', '畷', '南', '楠', '軟', '難', '汝', '二', '尼', '弐', '迩',
            '匂', '賑', '肉', '虹', '廿', '日', '乳', '入', '如', '尿', '韮', '任', '妊', '忍', '認', '濡',
            '禰', '祢', '寧', '葱', '猫', '熱', '年', '念', '捻', '撚', '燃', '粘', '乃', '廼', '之', '埜',
            '嚢', '悩', '濃', '納', '能', '脳', '膿', '農', '覗', '蚤', '巴', '把', '播', '覇', '杷', '波',
            '派', '琶', '破', '婆', '罵', '芭', '馬', '俳', '廃', '拝', '排', '敗', '杯', '盃', '牌', '背',
            '肺', '輩', '配', '倍', '培', '媒', '梅', '楳', '煤', '狽', '買', '売', '賠', '陪', '這', '蝿',
            '秤', '矧', '萩', '伯', '剥', '博', '拍', '柏', '泊', '白', '箔', '粕', '舶', '薄', '迫', '曝',
            '漠', '爆', '縛', '莫', '駁', '麦', '函', '箱', '硲', '箸', '肇', '筈', '櫨', '幡', '肌', '畑',
            '畠', '八', '鉢', '溌', '発', '醗', '髪', '伐', '罰', '抜', '筏', '閥', '鳩', '噺', '塙', '蛤',
            '隼', '伴', '判', '半', '反', '叛', '帆', '搬', '斑', '板', '氾', '汎', '版', '犯', '班', '畔',
            '繁', '般', '藩', '販', '範', '釆', '煩', '頒', '飯', '挽', '晩', '番', '盤', '磐', '蕃', '蛮',
            '匪', '卑', '否', '妃', '庇', '彼', '悲', '扉', '批', '披', '斐', '比', '泌', '疲', '皮', '碑',
            '秘', '緋', '罷', '肥', '被', '誹', '費', '避', '非', '飛', '樋', '簸', '備', '尾', '微', '枇',
            '毘', '琵', '眉', '美', '鼻', '柊', '稗', '匹', '疋', '髭', '彦', '膝', '菱', '肘', '弼', '必',
            '畢', '筆', '逼', '桧', '姫', '媛', '紐', '百', '謬', '俵', '彪', '標', '氷', '漂', '瓢', '票',
            '表', '評', '豹', '廟', '描', '病', '秒', '苗', '錨', '鋲', '蒜', '蛭', '鰭', '品', '彬', '斌',
            '浜', '瀕', '貧', '賓', '頻', '敏', '瓶', '不', '付', '埠', '夫', '婦', '富', '冨', '布', '府',
            '怖', '扶', '敷', '斧', '普', '浮', '父', '符', '腐', '膚', '芙', '譜', '負', '賦', '赴', '阜',
            '附', '侮', '撫', '武', '舞', '葡', '蕪', '部', '封', '楓', '風', '葺', '蕗', '伏', '副', '復',
            '幅', '服', '福', '腹', '複', '覆', '淵', '弗', '払', '沸', '仏', '物', '鮒', '分', '吻', '噴',
            '墳', '憤', '扮', '焚', '奮', '粉', '糞', '紛', '雰', '文', '聞', '丙', '併', '兵', '塀', '幣',
            '平', '弊', '柄', '並', '蔽', '閉', '陛', '米', '頁', '僻', '壁', '癖', '碧', '別', '瞥', '蔑',
            '箆', '偏', '変', '片', '篇', '編', '辺', '返', '遍', '便', '勉', '娩', '弁', '鞭', '保', '舗',
            '鋪', '圃', '捕', '歩', '甫', '補', '輔', '穂', '募', '墓', '慕', '戊', '暮', '母', '簿', '菩',
            '倣', '俸', '包', '呆', '報', '奉', '宝', '峰', '峯', '崩', '庖', '抱', '捧', '放', '方', '朋',
            '法', '泡', '烹', '砲', '縫', '胞', '芳', '萌', '蓬', '蜂', '褒', '訪', '豊', '邦', '鋒', '飽',
            '鳳', '鵬', '乏', '亡', '傍', '剖', '坊', '妨', '帽', '忘', '忙', '房', '暴', '望', '某', '棒',
            '冒', '紡', '肪', '膨', '謀', '貌', '貿', '鉾', '防', '吠', '頬', '北', '僕', '卜', '墨', '撲',
            '朴', '牧', '睦', '穆', '釦', '勃', '没', '殆', '堀', '幌', '奔', '本', '翻', '凡', '盆', '摩',
            '磨', '魔', '麻', '埋', '妹', '昧', '枚', '毎', '哩', '槙', '幕', '膜', '枕', '鮪', '柾', '鱒',
            '桝', '亦', '俣', '又', '抹', '末', '沫', '迄', '侭', '繭', '麿', '万', '慢', '満', '漫', '蔓',
            '味', '未', '魅', '巳', '箕', '岬', '密', '蜜', '湊', '蓑', '稔', '脈', '妙', '粍', '民', '眠',
            '務', '夢', '無', '牟', '矛', '霧', '鵡', '椋', '婿', '娘', '冥', '名', '命', '明', '盟', '迷',
            '銘', '鳴', '姪', '牝', '滅', '免', '棉', '綿', '緬', '面', '麺', '摸', '模', '茂', '妄', '孟',
            '毛', '猛', '盲', '網', '耗', '蒙', '儲', '木', '黙', '目', '杢', '勿', '餅', '尤', '戻', '籾',
            '貰', '問', '悶', '紋', '門', '匁', '也', '冶', '夜', '爺', '耶', '野', '弥', '矢', '厄', '役',
            '約', '薬', '訳', '躍', '靖', '柳', '薮', '鑓', '愉', '愈', '油', '癒', '諭', '輸', '唯', '佑',
            '優', '勇', '友', '宥', '幽', '悠', '憂', '揖', '有', '柚', '湧', '涌', '猶', '猷', '由', '祐',
            '裕', '誘', '遊', '邑', '郵', '雄', '融', '夕', '予', '余', '与', '誉', '輿', '預', '傭', '幼',
            '妖', '容', '庸', '揚', '揺', '擁', '曜', '楊', '様', '洋', '溶', '熔', '用', '窯', '羊', '耀',
            '葉', '蓉', '要', '謡', '踊', '遥', '陽', '養', '慾', '抑', '欲', '沃', '浴', '翌', '翼', '淀',
            '羅', '螺', '裸', '来', '莱', '頼', '雷', '洛', '絡', '落', '酪', '乱', '卵', '嵐', '欄', '濫',
            '藍', '蘭', '覧', '利', '吏', '履', '李', '梨', '理', '璃', '痢', '裏', '裡', '里', '離', '陸',
            '律', '率', '立', '葎', '掠', '略', '劉', '流', '溜', '琉', '留', '硫', '粒', '隆', '竜', '龍',
            '侶', '慮', '旅', '虜', '了', '亮', '僚', '両', '凌', '寮', '料', '梁', '涼', '猟', '療', '瞭',
            '稜', '糧', '良', '諒', '遼', '量', '陵', '領', '力', '緑', '倫', '厘', '林', '淋', '燐', '琳',
            '臨', '輪', '隣', '鱗', '麟', '瑠', '塁', '涙', '累', '類', '令', '伶', '例', '冷', '励', '嶺',
            '怜', '玲', '礼', '苓', '鈴', '隷', '零', '霊', '麗', '齢', '暦', '歴', '列', '劣', '烈', '裂',
            '廉', '恋', '憐', '漣', '煉', '簾', '練', '聯', '蓮', '連', '錬', '呂', '魯', '櫓', '炉', '賂',
            '路', '露', '労', '婁', '廊', '弄', '朗', '楼', '榔', '浪', '漏', '牢', '狼', '篭', '老', '聾',
            '蝋', '郎', '六', '麓', '禄', '肋', '録', '論', '倭', '和', '話', '歪', '賄', '脇', '惑', '枠',
            '鷲', '亙', '亘', '鰐', '詫', '藁', '蕨', '椀', '湾', '碗', '腕', '\0', '\0', '\0', '\0', '\0',
            '\0', '\0', ' ', ' ', '\0', ' ', '\0', '\0', '\0', '\0', '　', '\0', '\0', '\0', '\0', '\0',
            '\0', '\0', '\0', '\0', '\0', '\0', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　',
            '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '　', '酩', '酊', '煌', '蜃', '熾',
            '祠', '跋', '扈', '巫', '憫', '蟲', '磔', '倅', '殲', '丼', '刹', '絆', '綺', '踪', '囁', '傲',
            '貪', '偃', '榴', '弩', '鴉', '韋', '脛', '鋏', '髑', '髏', '祟', '鬱', '悍', '佇', '嗚', '邂',
            '逅', 'Ⅰ', 'Ⅳ', '埒', '騙', '贖', '罠', '眸', '謳', '號', '蜻', '蛉', '鬣', '蠢', '洒', '眩',
            '曰', '贄', '奢', '呟', '曖', '峙', '枷', '珈', '琲', '璧', '椒', '舐', '憑', '暫', '恍', '渾',
            '颯', '痺', '賽', '瞑', '籠', '祀', '攪', '絆', '驕', '嬌', '眞', '祓', '闊', '唸', '埃', '呻',
            '焉', '鉈', '逞', '頷', '磋', '漱', '垓', '梵', '嗅', '甦', '淹', '慄', '嘘', '笄', '藺', '踵',
            '澪', '凰', '鉤', '搏', '搗', '褄', '拗', '餃', '媚', '炸', '睨', '訝', '炒', '茹', '囮', '轢',
            '彷', '拉', '爛', '駘', '訛', '鈿', '沽', '遽', '艘'
        };
    }
}
