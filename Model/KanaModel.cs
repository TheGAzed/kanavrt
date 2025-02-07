namespace kanavrt.Model {
	public class Kana {
		public Kana(string[] latin, string pronunciation) {
			Latin = latin;
			Pronunciation = pronunciation;
		}

		public string[] Latin { get; set; }
		public string Pronunciation { get; set; }
		public int Wrongs { get; set; } = 0;
		public int Corrects { get; set; } = 0;
	}

	public class KanaModel {
		public HashSet<String> characters = new() {
					"\u3042", "\u3044", "\u3046", "\u3048", "\u304a",
					"\u304b", "\u304d", "\u304f", "\u3051", "\u3053",
					"\u3055", "\u3057", "\u3059", "\u305b", "\u305d",
					"\u305f", "\u3061", "\u3064", "\u3066", "\u3068",
					"\u306a", "\u306b", "\u306c", "\u306d", "\u306e",
					"\u306f", "\u3072", "\u3075", "\u3078", "\u307b",
					"\u307e", "\u307f", "\u3080", "\u3081", "\u3082",
					"\u3084",           "\u3086",           "\u3088",
					"\u3089", "\u308a", "\u308b", "\u308c", "\u308d",
					"\u308f",                               "\u3092",
			"\u3093",
		};

		public Dictionary<String, Kana> lookup = new() {
			// MONOGRAPHS
			{ "\u3042", new( ["A"],  "[a]") }, { "\u3044", new([        "I"],   "[i]") }, { "\u3046", new([        "U"],   "[ɯ]") }, { "\u3048", new([      "E"],  "[e]") }, { "\u304a", new([      "O"],  "[o]") },
			{ "\u304b", new(["KA"], "[ka]") }, { "\u304d", new([       "KI"],  "[ki]") }, { "\u304f", new([       "KU"],  "[kɯ]") }, { "\u3051", new([     "KE"], "[ke]") }, { "\u3053", new([     "KO"], "[ko]") },
			{ "\u3055", new(["SA"], "[sa]") }, { "\u3057", new(["SI", "SHI"],  "[ɕi]") }, { "\u3059", new([       "SU"],  "[sɯ]") }, { "\u305b", new([     "SE"], "[se]") }, { "\u305d", new([     "SO"], "[so]") },
			{ "\u305f", new(["TA"], "[ta]") }, { "\u3061", new(["TI", "CHI"], "[tɕi]") }, { "\u3064", new(["TU", "TSU"], "[tsɯ]") }, { "\u3066", new([     "TE"], "[te]") }, { "\u3068", new([     "TO"], "[to]") },
			{ "\u306a", new(["NA"], "[na]") }, { "\u306b", new([       "NI"],  "[ɲi]") }, { "\u306c", new([       "NU"],  "[nɯ]") }, { "\u306d", new([     "NE"], "[ne]") }, { "\u306e", new([     "NO"], "[no]") }, 
			{ "\u306f", new(["HA"], "[ha]") }, { "\u3072", new([       "HI"],  "[çi]") }, { "\u3075", new(["HU",  "FU"],  "[ɸɯ]") }, { "\u3078", new([     "HE"], "[he]") }, { "\u307b", new([     "HO"], "[ho]") },  
			{ "\u307e", new(["MA"], "[ma]") }, { "\u307f", new([       "MI"],  "[mi]") }, { "\u3080", new([       "MU"],  "[mɯ]") }, { "\u3081", new([     "ME"], "[me]") }, { "\u3082", new([     "MO"], "[mo]") }, 
			{ "\u3084", new(["YA"], "[ja]") },                                            { "\u3086", new([       "YU"],  "[jɯ]") },                                         { "\u3088", new([     "YO"], "[jo]") },
			{ "\u3089", new(["RA"], "[ra]") }, { "\u308a", new([       "RI"],  "[ri]") }, { "\u308b", new([       "RU"],  "[rɯ]") }, { "\u308c", new([     "RE"], "[re]") }, { "\u308d", new([     "RO"], "[ro]") },
			{ "\u308f", new(["WA"], "[wa]") }, { "\u3090", new([       "WI"],   "[i]") },                                            { "\u3091", new(["WE", "E"],  "[e]") }, { "\u3092", new(["WO", "O"],  "[o]") },

			{ "\u3093", new( ["N"], "[m n ɲ ŋ ɴ ɰ̃]") },

			// DIOGRAPHS
			//       ya                                               yu                                               yo
			{ "\u304D\u3083", new([       "KYA"], "[kʲa]") }, {"\u304D\u3085", new([       "KYU"], "[kʲɯ]") }, {"\u304D\u3087", new([       "KYO"], "[kʲo]") }, // k
			{ "\u3057\u3083", new(["SYA", "SHA"],  "[ɕa]") }, {"\u3057\u3085", new(["SYU", "SHU"],  "[ɕɯ]") }, {"\u3057\u3087", new(["SYO", "SHO"],  "[ɕo]") }, // s
			{ "\u3061\u3083", new(["TYA", "CHA"], "[tɕa]") }, {"\u3061\u3085", new(["TYU", "CHU"], "[tɕɯ]") }, {"\u3061\u3087", new(["TYO", "CHO"], "[tɕo]") }, // t
			{ "\u306B\u3083", new([       "NYA"],  "[ɲa]") }, {"\u306B\u3085", new([       "NYU"],  "[ɲɯ]") }, {"\u306B\u3087", new([       "NYO"],  "[ɲo]") }, // n
			{ "\u3072\u3083", new([       "HYA"],  "[ça]") }, {"\u3072\u3085", new([       "HYU"],  "[çɯ]") }, {"\u3072\u3087", new([       "HYO"],  "[ço]") }, // m
			{ "\u307F\u3083", new([       "MYA"], "[mʲa]") }, {"\u307F\u3085", new([       "MYU"], "[mʲɯ]") }, {"\u307F\u3087", new([       "MYO"], "[mʲo]") }, // h
			{ "\u308A\u3083", new([       "RYA"], "[ɾʲa]") }, {"\u308A\u3085", new([       "RYU"], "[ɾʲɯ]") }, {"\u308A\u3087", new([       "RYO"], "[ɾʲo]") }, // r

			// DIACRITIC MONOGRAPHS
			//    a                                     i                          u                          e                          o
			{ "\u304C", new(["GA"],    "[ɡa]") }, { "\u304E", new([      "GI"],    "[ɡi]") }, { "\u3050", new([      "GU"],    "[ɡɯ]") }, { "\u3052", new(["GE"],    "[ɡe]") }, { "\u3054", new(["GO"],    "[ɡo]") }, // g
			{ "\u3056", new(["ZA"], "[(d)za]") }, { "\u3058", new(["ZI", "JI"], "[(d)ʑi]") }, { "\u305A", new([      "ZU"], "[(d)zɯ]") }, { "\u305C", new(["ZE"], "[(d)ze]") }, { "\u305E", new(["ZO"], "[(d)zo]") }, // z
			{ "\u3060", new(["DA"],    "[da]") }, { "\u3062", new(["DI", "JI"], "[(d)ʑi]") }, { "\u3065", new(["DU", "ZU"], "[(d)zɯ]") }, { "\u3067", new(["DE"],    "[de]") }, { "\u3069", new(["DO"],    "[do]") }, // d
			{ "\u3070", new(["BA"],    "[ba]") }, { "\u3073", new([      "BI"],    "[bi]") }, { "\u3076", new([      "BU"],    "[bɯ]") }, { "\u3079", new(["BE"],    "[be]") }, { "\u307C", new(["BO"],    "[bo]") }, // b
			{ "\u3071", new(["PA"],    "[pa]") }, { "\u3074", new([      "PI"],    "[pi]") }, { "\u3077", new([      "PU"],    "[pɯ]") }, { "\u307A", new(["PE"],    "[pe]") }, { "\u307D", new(["PO"],    "[po]") }, // p

			// DIACRITIC DIGRAPHSN
			//      ya                             yu                             yo
			{ "\u304E\u3083", new([      "GYA"],   "[ɡʲa]") }, { "\u304E\u3085", new([      "GYU"],   "[ɡʲɯ]") }, { "\u304E\u3087", new([      "GYO"],   "[ɡʲo]") }, // g
			{ "\u3058\u3083", new(["ZYA", "JA"], "[(d)ʑa]") }, { "\u3058\u3085", new(["ZYU", "JU"], "[(d)ʑɯ]") }, { "\u3058\u3087", new(["ZYO", "JO"], "[(d)ʑo]") }, // z
			{ "\u3062\u3083", new(["DYA", "JA"], "[(d)ʑa]") }, { "\u3062\u3085", new(["DYU", "JU"], "[(d)ʑɯ]") }, { "\u3062\u3087", new(["DYO", "JO"], "[(d)ʑo]") }, // d
			{ "\u3073\u3083", new([      "BYA"],   "[bʲa]") }, { "\u3073\u3085", new([      "BYU"],   "[bʲɯ]") }, { "\u3073\u3087", new([      "BYO"],   "[bʲo]") }, // b
			{ "\u3074\u3083", new([      "PYA"],   "[pʲa]") }, { "\u3074\u3085", new([      "PYU"],   "[pʲɯ]") }, { "\u3074\u3087", new([      "PYO"],   "[pʲo]") }, // p
        };
	}
}
