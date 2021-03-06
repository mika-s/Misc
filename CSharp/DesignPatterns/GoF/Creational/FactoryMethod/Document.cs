﻿using System.Collections.Generic;

namespace DesignPatterns.GoF.Creational.FactoryMethod
{
    public abstract class Document
    {
        public Document()
        {
            Pages = new List<IPage>();
            Create();
        }

        public List<IPage> Pages { get; private set; }

        public abstract void Create();
    }
}
