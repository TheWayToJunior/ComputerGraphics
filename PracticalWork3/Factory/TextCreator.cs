using PracticalWork3.Abstractions;
using PracticalWork3.Models;
using System.Collections.Generic;
using System.Drawing;

namespace PracticalWork3.Factory
{
    public class TextCreator
    {
        public int CountItemsCreated { get; private set; } = 0;

        public IEnumerable<BaseText> Create(SmallFactory factory, string text, Font font, StringAlignment alignment, int count)
        {
            var list = new List<BaseText>();

            for (int i = 0; i < count; i++, CountItemsCreated++)
            {
                list.Add(factory.Create($"{text} {CountItemsCreated}", font, alignment));
            }

            return list;
        }
    }
}
