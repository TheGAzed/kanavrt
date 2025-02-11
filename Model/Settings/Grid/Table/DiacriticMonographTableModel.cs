
namespace kanavrt.Model.Settings.Grid.Table {
	public class DiacriticMonographTableModel() : AbstractTableModel(5, 5, false, false) {
		public override HashSet<string>[] ConsonantsLineSetLookupSet() {
			return [
				[ "\u304C", "\u304E", "\u3050", "\u3052", "\u3054", ],
				[ "\u3056", "\u3058", "\u305A", "\u305C", "\u305E", ],
				[ "\u3060", "\u3062", "\u3065", "\u3067", "\u3069", ],
				[ "\u3070", "\u3073", "\u3076", "\u3079", "\u307C", ],
				[ "\u3071", "\u3074", "\u3077", "\u307A", "\u307D", ],
			];
		}

		public override HashSet<string> ConsonantsSetSet() {
			return [
				"\u304C", "\u304E", "\u3050", "\u3052", "\u3054",
				"\u3056", "\u3058", "\u305A", "\u305C", "\u305E",
				"\u3060", "\u3062", "\u3065", "\u3067", "\u3069",
				"\u3070", "\u3073", "\u3076", "\u3079", "\u307C",
				"\u3071", "\u3074", "\u3077", "\u307A", "\u307D",
			];
		}

		public override HashSet<string>[] VowelsLineSetLookupSet() {
			return [
				[ "\u304C", "\u3056", "\u3060", "\u3070", "\u3071", ],
				[ "\u304E", "\u3058", "\u3062", "\u3073", "\u3074", ],
				[ "\u3050", "\u305A", "\u3065", "\u3076", "\u3077", ],
                [ "\u3052", "\u305C", "\u3067", "\u3079", "\u307A", ],
                [ "\u3054", "\u305E", "\u3069", "\u307C", "\u307D", ],
			];
		}

		public override HashSet<string> VowelsSetSet() {
			return [];
		}
	}
}
