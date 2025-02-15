namespace kanavrt.Model.Statistics {
	public class KanaStatistics {
		public int Wrongs { get; set; } = 0;
		public int Corrects { get; set; } = 0;
	}

	public class StatisticsModel {
		public Dictionary<string, KanaStatistics> lookup = new() {
			// MONOGRAPHS
			{ "\u3042", new() }, { "\u3044", new() }, { "\u3046", new() }, { "\u3048", new() }, { "\u304a", new() },
			{ "\u304b", new() }, { "\u304d", new() }, { "\u304f", new() }, { "\u3051", new() }, { "\u3053", new() },
			{ "\u3055", new() }, { "\u3057", new() }, { "\u3059", new() }, { "\u305b", new() }, { "\u305d", new() },
			{ "\u305f", new() }, { "\u3061", new() }, { "\u3064", new() }, { "\u3066", new() }, { "\u3068", new() },
			{ "\u306a", new() }, { "\u306b", new() }, { "\u306c", new() }, { "\u306d", new() }, { "\u306e", new() },
			{ "\u306f", new() }, { "\u3072", new() }, { "\u3075", new() }, { "\u3078", new() }, { "\u307b", new() },
			{ "\u307e", new() }, { "\u307f", new() }, { "\u3080", new() }, { "\u3081", new() }, { "\u3082", new() },
			{ "\u3084", new() },                      { "\u3086", new() },                      { "\u3088", new() },
			{ "\u3089", new() }, { "\u308a", new() }, { "\u308b", new() }, { "\u308c", new() }, { "\u308d", new() },
			{ "\u308f", new() }, { "\u3090", new() },                      { "\u3091", new() }, { "\u3092", new() },

			{ "\u3093", new() },

			// DIGRAPHS
			//       ya                        yu                        yo
			{ "\u304D\u3083", new() }, {"\u304D\u3085", new() }, {"\u304D\u3087", new() }, // k
			{ "\u3057\u3083", new() }, {"\u3057\u3085", new() }, {"\u3057\u3087", new() }, // s
			{ "\u3061\u3083", new() }, {"\u3061\u3085", new() }, {"\u3061\u3087", new() }, // t
			{ "\u306B\u3083", new() }, {"\u306B\u3085", new() }, {"\u306B\u3087", new() }, // n
			{ "\u3072\u3083", new() }, {"\u3072\u3085", new() }, {"\u3072\u3087", new() }, // m
			{ "\u307F\u3083", new() }, {"\u307F\u3085", new() }, {"\u307F\u3087", new() }, // h
			{ "\u308A\u3083", new() }, {"\u308A\u3085", new() }, {"\u308A\u3087", new() }, // r

			// DIACRITIC MONOGRAPHS
			//    a                                     i                          u                          e                          o
			{ "\u304C", new() }, { "\u304E", new() }, { "\u3050", new() }, { "\u3052", new() }, { "\u3054", new() }, // g
			{ "\u3056", new() }, { "\u3058", new() }, { "\u305A", new() }, { "\u305C", new() }, { "\u305E", new() }, // z
			{ "\u3060", new() }, { "\u3062", new() }, { "\u3065", new() }, { "\u3067", new() }, { "\u3069", new() }, // d
			{ "\u3070", new() }, { "\u3073", new() }, { "\u3076", new() }, { "\u3079", new() }, { "\u307C", new() }, // b
			{ "\u3071", new() }, { "\u3074", new() }, { "\u3077", new() }, { "\u307A", new() }, { "\u307D", new() }, // p

			// DIACRITIC DIGRAPHSN
			//       ya                         yu                         yo
			{ "\u304E\u3083", new() }, { "\u304E\u3085", new() }, { "\u304E\u3087", new() }, // g
			{ "\u3058\u3083", new() }, { "\u3058\u3085", new() }, { "\u3058\u3087", new() }, // z
			{ "\u3062\u3083", new() }, { "\u3062\u3085", new() }, { "\u3062\u3087", new() }, // d
			{ "\u3073\u3083", new() }, { "\u3073\u3085", new() }, { "\u3073\u3087", new() }, // b
			{ "\u3074\u3083", new() }, { "\u3074\u3085", new() }, { "\u3074\u3087", new() }, // p
        };
	}
}
