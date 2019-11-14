using FourCharacterPhrase.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Timers;

namespace FourCharacterPhrase.Blazor.Pages
{
    public class IndexBase : ComponentBase
    {
        public BordEntity Bord { get; set; } = new BordEntity();

        public string Message { get; set; } = "";


        protected override void OnInitialized()
        {
            Bord.SetData();
        }

        public void StartGame()
        {
            Bord.SetData();

            StateHasChanged();
        }

        protected void BordClick(CellEntity cell)
        {
            Bord.Click(cell);

            if (Bord.IsCompleted() == true)
            {
                Message = "Completed";
            }

            StateHasChanged();
        }

        protected string GetCss(CellStatus cellStatus)
        {
            switch (cellStatus)
            {
                case CellStatus.None:
                    return "btn-lg btn-info";
                case CellStatus.Selecting:
                    return "btn-lg btn-primary";
                case CellStatus.Completed:
                    return "btn-lg btn-success";
                default:
                    return "btn-lg btn-info";
            }
            
        }
    }
}

