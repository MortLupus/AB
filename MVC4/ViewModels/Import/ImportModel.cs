using System.IO;
using System.Web;

namespace MVC4.ViewModels.Import
{
    public class ImportModel
    {
        public ProgramType Type { get; set; }
        public HttpPostedFile File { get; set; } 
    }

    public enum ProgramType 
    {
        BattleScribe
    }
}