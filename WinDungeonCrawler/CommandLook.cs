﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class CommandLook : BaseCommand
    {
        public override bool Perform(PlayerCharacter playerCharacter, string[] commandString)
        {
            playerCharacter.Position.DisplayRoom(playerCharacter);

            return false;
        }
    }
}
