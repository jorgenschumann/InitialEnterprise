﻿using InitialEnterprise.Shared.Dtos;

namespace InitialEnterprise.Frontend.Pages.User
{
    public class UserEditView : Component.ViewComponentBase
    {
        public UserDto User { get; set; } = new UserDto();
    }
}
