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

        private Timer timer;

        protected override void OnInitialized()
        {
            Bord.SetData();
        }

        public void StartGame()
        {
            Bord.SetData();

            //SetTimmer();

            StateHasChanged();
        }

        //private void SetTimmer()
        //{
        //    // Create a timer with a two second interval.
        //    timer = new Timer(1000);
        //    // Hook up the Elapsed event for the timer. 
        //    timer.Elapsed += OnTimedEvent;
        //    timer.AutoReset = true;
        //    timer.Enabled = true;
        //}

        protected void BordClick(CellEntity cell)
        {
            Bord.Click(cell);

            Message = Bord.GetElapsedTime().ToString();

            if (Bord.IsCompleted() == true)
            {
                //timer.Elapsed -= OnTimedEvent;
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

        //private void OnTimedEvent(Object source, ElapsedEventArgs e)
        //{
        //    Message = Bord.GetElapsedTime().ToString();
        //    StateHasChanged();
        //}
    }
}

