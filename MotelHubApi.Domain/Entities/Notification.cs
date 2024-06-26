﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotelHubApi;
public class Notification : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Category { get; set; }
    public bool Seen { get; set; }
    public int UserId { get; set; }
}
