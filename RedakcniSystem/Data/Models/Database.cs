﻿using System;
using System.Collections.Generic;

namespace RedakcniSystem.Data.Models
{
    public static class Database
    {

        public static List<Article> Articles()
        {
            return new List<Article>()
            {
                new Article()
            {
                Id = 69,
                Title = "Kvůli marihuaně strávil osm let za mřížemi, dnes mu vydělává velké peníze",
                Content = "Aby se stal úspěšným podnikatelem, musel ujít skutečně dlouhou cestu. Američan Mike Biggio si odpykal osm let ve vězení za obchod s marihuanou, následně byl vyhozen z práce, aby dnes mohl říct, že je spolumajitelem jedné z nějvětších konopných farem na světě. ",
                Author = "Jakub Štěpánek",
                Created = new DateTime(2021, 02, 27, 7, 37, 00),
            },
                   new Article()          {
                Id = 7,
                Title = "Orion a spol. Zlatý věk českých cukrovinek začal před více než sto lety",
                Content = "České cukrovinky a jejich výrobci byli známí už od středověku. Nenabízeli ovšem zboží, po kterém baží dnešní mlsalové. To se objevilo na pultech a kavárenských stolcích až ve druhé polovině 19. století – tehdy došlo ke změně v cukrárenském odvětví díky využívání nových technologií. ",
                Author = "Lenka Bobíková",
                Created = new DateTime(2021, 02, 21, 9, 14, 00),
            },
            };
        }

        public static List<Email> Emails()
        {
            return new List<Email>()
            {
                new Email() {
                    EmailAddress="maruscak.jan@ssakhk.cz",
                    Id=1
                },
                                new Email() {
                    EmailAddress="maruscak.jan@kyberna.cz",
                    Id=1
                },
            };

        }


    }
}