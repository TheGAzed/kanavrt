using System.Runtime.CompilerServices;

namespace kanavrt.Model.Settings.Grid.Table {
	public class MonographTableModel() : AbstractTableModel(5, 10, true, true) {
		public override HashSet<string>[] ConsonantsLineSetLookupSet() {
			return [
				[           "\u304b", "\u304d", "\u304f", "\u3051", "\u3053", ],
				[           "\u3055", "\u3057", "\u3059", "\u305b", "\u305d", ],
				[           "\u305f", "\u3061", "\u3064", "\u3066", "\u3068", ],
				[           "\u306a", "\u306b", "\u306c", "\u306d", "\u306e", ],
				[           "\u306f", "\u3072", "\u3075", "\u3078", "\u307b", ],
				[           "\u307e", "\u307f", "\u3080", "\u3081", "\u3082", ],
				[           "\u3084",           "\u3086",           "\u3088", ],
				[           "\u3089", "\u308a", "\u308b", "\u308c", "\u308d", ],
				[           "\u308f", "\u3090",           "\u3091", "\u3092", ],
				[ "\u3093"                                                    ],
			];
		}

		public override HashSet<string> ConsonantsSetSet() {
			return [
						  "\u304b", "\u304d", "\u304f", "\u3051", "\u3053",
						  "\u3055", "\u3057", "\u3059", "\u305b", "\u305d",
						  "\u305f", "\u3061", "\u3064", "\u3066", "\u3068",
						  "\u306a", "\u306b", "\u306c", "\u306d", "\u306e",
						  "\u306f", "\u3072", "\u3075", "\u3078", "\u307b",
						  "\u307e", "\u307f", "\u3080", "\u3081", "\u3082",
						  "\u3084",           "\u3086",           "\u3088",
						  "\u3089", "\u308a", "\u308b", "\u308c", "\u308d",
						  "\u308f", "\u3090",           "\u3091", "\u3092",
				"\u3093",
			];
		}

		public override HashSet<string>[] VowelsLineSetLookupSet() {
			return [
				[ "\u3042", "\u304b", "\u3055", "\u305f", "\u306a", "\u306f", "\u307e", "\u3084", "\u3089", "\u308f", ],
				[ "\u3044", "\u304d", "\u3057", "\u3061", "\u306b", "\u3072", "\u307f", "\u308a", "\u3090",           ],
				[ "\u3046", "\u304f", "\u3059", "\u3064", "\u306c", "\u3075", "\u3080", "\u3086", "\u308b",           ],
				[ "\u3048", "\u3051", "\u305b", "\u3066", "\u306d", "\u3078", "\u3081", "\u308c", "\u3091",           ],
				[ "\u304a", "\u3053", "\u305d", "\u3068", "\u306e", "\u307b", "\u3082", "\u3088", "\u308d", "\u3092", ],
			];
		}

		public override HashSet<string> VowelsSetSet() {
			return VowelsSet = ["\u3042", "\u3044", "\u3046", "\u3048", "\u304a",];
		}
	}
}
