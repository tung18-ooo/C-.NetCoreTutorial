﻿namespace CS047_ASP.NET_CORE_4.Options
{
    public class TestOptions
    {
        public string opt_key1 {  get; set; }
        public SubTestOptions opt_key2 { get; set; }
    }

    public class SubTestOptions
    {
        public string k1 { get; set; }
        public string k2 { get; set; }
    }
}
