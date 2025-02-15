namespace kanavrt.Model.Settings {
	public enum FontType {
		Unset = 0,
		ZenKurenaido = 1,
		DotGothic16 = 2,

		Hannari = 3,
		AoboshiOne = 4,
		CherryBombOne = 5,

		DelaGothicOne = 6,
		MonomaniacOne = 7,
		Chokokutai = 8,
	}

	public class SettingsModel {
		public readonly Dictionary<FontType, string> lookup = new() {
			{ FontType.Unset,        "unset"         },
			{ FontType.ZenKurenaido, "Zen Kurenaido" },
			{ FontType.DotGothic16,  "DotGothic16"   },

			{ FontType.Hannari,       "Hannari"   },
			{ FontType.AoboshiOne,    "Aoboshi One"   },
			{ FontType.CherryBombOne, "Cherry Bomb One"   },

			{ FontType.DelaGothicOne, "Dela Gothic One"   },
			{ FontType.MonomaniacOne, "Monomaniac One"   },
			{ FontType.Chokokutai,    "Chokokutai"   },
		};

		public FontType Font { get; set; } = FontType.Unset;

		public HashSet<string> characters = [
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
		];
	}
}
