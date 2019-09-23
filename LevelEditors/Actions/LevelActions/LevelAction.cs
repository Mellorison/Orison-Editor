using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrisonEditor.LevelData;

namespace OrisonEditor.LevelEditors.Actions.LevelActions
{
    public abstract class LevelAction : OrisonAction
    {
        public Level Level { get; private set; }

        public LevelAction(Level level)
        {
            Level = level;
        }
    }
}
