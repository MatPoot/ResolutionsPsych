using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResolutionsPsych;
using ResolutionsPsych.Classes;

namespace ResolutionsPsych.Pages
{
    [BindProperties]
    public class ViewClientsModel : PageModel
    {
        public List<Client> ListOfClients { get; set; }
        public int ClientToModify { get; set; }
        public void OnGet()
        {
            ListOfClients = SqlHelper.GetClients();
        }
        public void OnPost()
        {
            //need code here for delete client, need to write SQL methods / command first
        }

    }
}
