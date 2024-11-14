namespace kanavrt.Model {
	public struct Kana {
		public Kana(string[] latin, int[] coordinates, string pronunciation) {
			Latin = latin;
			Coordinates = coordinates;
			Pronunciation = pronunciation;
		}

		public string[] Latin { get; set; }
		public int[] Coordinates{ get; set; }
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
			{ "\u3042", new( ["A"], [0, 1],  "[a]") }, { "\u3044", new([         "I"], [0, 2],   "[i]") }, { "\u3046", new([        "U"], [0, 3],   "[ɯ]") }, { "\u3048", new([      "E"], [0, 4],  "[e]") }, { "\u304a", new([      "O"], [0, 5],  "[o]") },
			{ "\u304b", new(["KA"], [1, 1], "[ka]") }, { "\u304d", new([        "KI"], [1, 2],  "[ki]") }, { "\u304f", new([       "KU"], [1, 3],  "[kɯ]") }, { "\u3051", new([     "KE"], [1, 4], "[ke]") }, { "\u3053", new([     "KO"], [1, 5], "[ko]") },
			{ "\u3055", new(["SA"], [2, 1], "[sa]") }, { "\u3057", new([ "SI", "SHI"], [2, 2],  "[ɕi]") }, { "\u3059", new([       "SU"], [2, 3],  "[sɯ]") }, { "\u305b", new([     "SE"], [2, 4], "[se]") }, { "\u305d", new([     "SO"], [2, 5], "[so]") },
			{ "\u305f", new(["TA"], [3, 1], "[ta]") }, { "\u3061", new(["CHI",  "TI"], [3, 2], "[tɕi]") }, { "\u3064", new(["TSU", "TU"], [3, 3], "[tsɯ]") }, { "\u3066", new([     "TE"], [3, 4], "[te]") }, { "\u3068", new([     "TO"], [3, 5], "[to]") },
			{ "\u306a", new(["NA"], [4, 1], "[na]") }, { "\u306b", new([        "NI"], [4, 2],  "[ɲi]") }, { "\u306c", new([       "NU"], [4, 3],  "[nɯ]") }, { "\u306d", new([     "NE"], [4, 4], "[ne]") }, { "\u306e", new([     "NO"], [4, 5], "[no]") }, 
			{ "\u306f", new(["HA"], [5, 1], "[ha]") }, { "\u3072", new([        "HI"], [5, 2],  "[çi]") }, { "\u3075", new([ "FU", "HU"], [5, 3],  "[ɸɯ]") }, { "\u3078", new([     "HE"], [5, 4], "[he]") }, { "\u307b", new([     "HO"], [5, 5], "[ho]") },  
			{ "\u307e", new(["MA"], [6, 1], "[ma]") }, { "\u307f", new([        "MI"], [6, 2],  "[mi]") }, { "\u3080", new([       "MU"], [6, 3],  "[mɯ]") }, { "\u3081", new([     "ME"], [6, 4], "[me]") }, { "\u3082", new([     "MO"], [6, 5], "[mo]") }, 
			{ "\u3084", new(["YA"], [7, 1], "[ja]") },                                                     { "\u3086", new([       "YU"], [7, 3],  "[jɯ]") },                                                 { "\u3088", new([     "YO"], [7, 5], "[jo]") },
			{ "\u3089", new(["RA"], [8, 1], "[ra]") }, { "\u308a", new([        "RI"], [8, 2],  "[ri]") }, { "\u308b", new([       "RU"], [8, 3],  "[rɯ]") }, { "\u308c", new([     "RE"], [8, 4], "[re]") }, { "\u308d", new([     "RO"], [8, 5], "[ro]") },
			{ "\u308f", new(["WA"], [9, 1], "[wa]") }, { "\u3090", new([        "WI"], [9, 2],   "[i]") },                                                    { "\u3091", new(["E", "WE"], [9, 4],  "[e]") }, { "\u3092", new(["O", "WO"], [0, 1],  "[o]") },

			{ "\u3093", new( ["N"], [10, 0], "[m n ɲ ŋ ɴ ɰ̃]") },
		};
	}
}
