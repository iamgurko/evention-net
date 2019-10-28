﻿using System.Collections.Generic;
using Evention.Core.Models;

namespace Evention.Core.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();
    }
}