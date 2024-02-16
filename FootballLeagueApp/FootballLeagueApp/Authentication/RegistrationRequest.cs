﻿using System.ComponentModel.DataAnnotations;

namespace FootballLeagueApp.Authentication;

public record RegistrationRequest
(
    [Required] string Email,
    [Required] string UserName,
    [Required] string Password
);