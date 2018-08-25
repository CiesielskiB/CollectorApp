using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorApp.Core.Models
{
	public class Game : Subject
	{
		public string Developer { get; set; }
		public int Discs { get; set; }
	}
}
