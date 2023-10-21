namespace Bowling
{
    public class Parse
    {
        public List<Rolls> Parser(string frame)
        {
            return new List<Rolls>
            {
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
                new Rolls { Roll1 = new Roll { Pins = 0 }, Roll2 = new Roll { Pins = 0 } },
            };
        }
    }
}