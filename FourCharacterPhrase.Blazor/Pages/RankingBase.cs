using FourCharacterPhrase.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FourCharacterPhrase.Blazor.Pages
{
    public class RankingBase : ComponentBase
    {
        protected List<AnswerNumberEntity> AnswerNumberEntitys = new List<AnswerNumberEntity>();

        protected override async Task OnInitializedAsync()
        {
            AnswerNumberEntitys = await WebApiService.GetRequest< List<AnswerNumberEntity>,string >("AnswerNumber", "");
        }
    }
}
