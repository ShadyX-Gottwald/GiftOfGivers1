﻿using System.ComponentModel.DataAnnotations;

namespace GiftOfGivers1.Models;

public class UserProfile {

    [Key]
     public int Id { get; set; }
    public string Email { get; set; }  
    public string UserName { get; set; } 

    public string Address { get; set; }

    
}
