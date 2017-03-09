namespace FunFacts.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FunFacts.Models.FunFactsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FunFacts.Models.FunFactsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.FunFacts.AddOrUpdate(
               f => f.id,
                 new FunFacts.Models.FunFact { id = 1, description = "Un dia Chuck Norris estaba comiendo carne de ternera y cansado de comer lo mismo dijo hágase un animal del cual yo podria alimentar sin volar de mis patadas giratorias" },
                 new FunFacts.Models.FunFact { id = 2, description = "A persar de lo que digan los gallinas...¡Chuck es bostero de corazón! y amigo del Rafa Di Zeo" },
                 new FunFacts.Models.FunFact { id = 3, description = "Chuck norris puede matar dos tiros de un pájaro." },
                 new FunFacts.Models.FunFact { id = 4, description = "Hay 1424 cosas en una habitación promedio con las que Chuck Norris podría matarte. Incluyendo la habitación en sí." },
                 new FunFacts.Models.FunFact { id = 5, description = "Chuck Norris no duerme. Espera" },
                 new FunFacts.Models.FunFact { id = 6, description = "Chuck Norris no lee el periódico, lo estudia" },
                 new FunFacts.Models.FunFact { id = 7, description = "Chuck Norris no juega a nada, lo gana." },
                 new FunFacts.Models.FunFact { id = 8, description = "Chuck Norris cuando defeca, deja el aire con olor a Axe." },
                 new FunFacts.Models.FunFact { id = 9, description = "Chuck Norris invento a su padre" },
                 new FunFacts.Models.FunFact { id = 10, description = "No existe la teoría de la evolución, tan sólo una lista de las especies que Chuck Norris permite vivir." },
                 new FunFacts.Models.FunFact { id = 11, description = "Chuck Norris no te pisa un pie, sino el cuello." },
                 new FunFacts.Models.FunFact { id = 12, description = "Los chavales dibujan su nombre en la nieve meando. Chuck Norris hace lo mismo en cemento." },
                 new FunFacts.Models.FunFact { id = 13, description = "En los exámenes de matemáticas de Chuck Norris, la respuesta a todas las preguntas fue" },
                 new FunFacts.Models.FunFact { id = 14, description = "Chuck Norris borró la papelera de reciclaje" },
                 new FunFacts.Models.FunFact { id = 15, description = "Cuando Chuck Norris corre sosteniendo delante de su cara unas tijeras abiertas y tropieza, todos a su alrededor se hacen daño." }
             );
        }
    }
}
