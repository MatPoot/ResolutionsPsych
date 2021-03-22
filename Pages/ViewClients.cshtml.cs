using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PsychApp;
using PsychApp.Classes;

namespace ResolutionsPsych.Pages
{
    [BindProperties]
    public class ViewClientsModel : PageModel
    {
        public List<Client> ListOfClients { get; set; }
        public void OnGet()
        {
            ListOfClients = SqlHelper.GetClients();
        }
    }
}
