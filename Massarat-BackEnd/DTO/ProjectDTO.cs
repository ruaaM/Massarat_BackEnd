using Massarat.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Massarat_BackEnd.DTO
{
	public class ProjectDTO { 
	
		public String Name { get; set; }

		public String Description { get; set; }

		public virtual String MentorName { get; set; }
		public String Industry { get; set; }

		public int TeamNumber { get; set; }
	}
}
