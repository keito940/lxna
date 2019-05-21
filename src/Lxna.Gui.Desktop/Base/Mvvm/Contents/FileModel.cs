﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using Lxna.Gui.Desktop.Base.Mvvm.Primitives;
using Lxna.Messages;

namespace Lxna.Gui.Desktop.Models
{
    public sealed class FileModel : BindableBase
    {
        public FileModel(LxnaContentId contentId)
        {
            this.ContentId = contentId;

            this.Name = Path.GetFileName(this.ContentId.Path);
        }

        public LxnaContentId ContentId { get; }

        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => this.SetProperty(ref _name, value);
        }
    }
}