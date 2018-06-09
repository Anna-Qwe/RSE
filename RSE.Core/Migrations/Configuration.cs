namespace RSE.Core.Migrations
{
    using Newtonsoft.Json;
    using RSE.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RSE.Core.Context>
    {
        public class GeneralData
        {
            public List<Exercise> Exercises { get; set; }
            public List<Variant> Variants { get; set; }
            public List<User> Users { get; set; }
        }
        private const string DataFolder = "RSE.Core/Data";
        private const string FileName = "data.json";

        private GeneralData _generalData;
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RSE.Core.Context context)
        {
            using (var sr = new StreamReader(Path.Combine(DataFolder, FileName)))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    _generalData = serializer.Deserialize<GeneralData>(jsonReader);
                }
            }

            foreach (var var in _generalData.Variants)
            {
                context.Variants.AddOrUpdate(s => s.Name, entities: var);

                foreach (var ex in var.Exercises)
                {
                    context.Exercises.AddOrUpdate(s => s.Number, entities: ex);
                }
            }
        }
    }
}
