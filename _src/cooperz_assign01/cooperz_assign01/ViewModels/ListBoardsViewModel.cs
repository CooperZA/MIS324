using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cooperz_assign01.ViewModels.ListBoardsViewModel
{
    public class Boards
    {
        public string ModelName { get; set; }
        public string ModelId { get; set; }
        public int Price { get; set; }
    }
    public static class ListBoardsViewModel
    {
        public static List<Boards> BoardList = new List<Boards>
        {
            new Boards() { ModelName = "Screamer $200", ModelId = "scr", Price = 200},
            new Boards() { ModelName = "Terrorizer $300", ModelId = "ter", Price = 300},
            new Boards() { ModelName = "Cliff Hopper $400", ModelId = "cli", Price = 400},
            new Boards() { ModelName = "Low IQ $500", ModelId = "low", Price = 500}
        };
    }
}