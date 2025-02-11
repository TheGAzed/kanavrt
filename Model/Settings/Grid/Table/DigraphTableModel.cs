
namespace kanavrt.Model.Settings.Grid.Table {
	public class DigraphTableModel() : AbstractTableModel(3, 7, false, false) {
		public override HashSet<string>[] ConsonantsLineSetLookupSet() {
			return [
				[ "\u304D\u3083", "\u304D\u3085", "\u304D\u3087", ],
				[ "\u3057\u3083", "\u3057\u3085", "\u3057\u3087", ],
				[ "\u3061\u3083", "\u3061\u3085", "\u3061\u3087", ],
				[ "\u306B\u3083", "\u306B\u3085", "\u306B\u3087", ],
				[ "\u3072\u3083", "\u3072\u3085", "\u3072\u3087", ],
				[ "\u307F\u3083", "\u307F\u3085", "\u307F\u3087", ],
				[ "\u308A\u3083", "\u308A\u3085", "\u308A\u3087", ],
			];
		}

		public override HashSet<string> ConsonantsSetSet() {
			return [
				"\u304D\u3083", "\u304D\u3085", "\u304D\u3087",
				"\u3057\u3083", "\u3057\u3085", "\u3057\u3087",
				"\u3061\u3083", "\u3061\u3085", "\u3061\u3087",
				"\u306B\u3083", "\u306B\u3085", "\u306B\u3087",
				"\u3072\u3083", "\u3072\u3085", "\u3072\u3087",
				"\u307F\u3083", "\u307F\u3085", "\u307F\u3087",
				"\u308A\u3083", "\u308A\u3085", "\u308A\u3087",
			];
        }

		public override HashSet<string>[] VowelsLineSetLookupSet() {
            return [
                [ "\u304D\u3083", "\u3057\u3083", "\u3061\u3083", "\u306B\u3083", "\u3072\u3083", "\u307F\u3083", "\u308A\u3083", ],
                [ "\u304D\u3085", "\u3057\u3085", "\u3061\u3085", "\u306B\u3085", "\u3072\u3085", "\u307F\u3085", "\u308A\u3085", ],
                [ "\u304D\u3087", "\u3057\u3087", "\u3061\u3087", "\u306B\u3087", "\u3072\u3087", "\u307F\u3087", "\u308A\u3087", ],
            ];
        }



		public override HashSet<string> VowelsSetSet() {
			return [];
		}
	}
}
