using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Events.EventArgs.Server;
using System;
using System.ComponentModel;

namespace FriendlyFireOnRoundEnd
{
    public class FriendlyFireOnRoundEnd : Plugin<Config>
    {
        public override string Author => "gben5692";
        public override Version Version => new Version(1, 0, 0);    


        public override void OnEnabled()
        {
            base.OnEnabled();

            Exiled.Events.Handlers.Server.RoundEnded += OnRoundEnded;
            Exiled.Events.Handlers.Server.WaitingForPlayers += OnServerStart;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();

            Exiled.Events.Handlers.Server.RoundEnded -= OnRoundEnded;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= OnServerStart;
        }

        private void OnRoundEnded(RoundEndedEventArgs ev)
        {
            Server.FriendlyFire = true;
        }

        private void OnServerStart()
        {
            Server.FriendlyFire = false;
        }
    }

    public class Config : IConfig
    {
        
        public bool IsEnabled { get; set; } = true;

       
        public bool Debug { get; set; } = false;
    }
}
