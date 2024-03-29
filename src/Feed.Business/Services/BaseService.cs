﻿using Feed.Business.Interfaces;
using Feed.Business.Models;
using Feed.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace Feed.Business.Services;

public abstract class BaseService
{
    private readonly INotifier _notifier;

    public BaseService(INotifier notifier)
    {
        _notifier = notifier;
    }

    protected void Notify(ValidationResult validationResult)
    {
        validationResult.Errors.ForEach(e => Notify(e.ErrorMessage));
    }

    protected void Notify(string message)
    {
        _notifier.Add(new Notification(message));
    }

    protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
    {
        var validator = validation.Validate(entity);

        if (validator.IsValid)
            return true;

        Notify(validator);

        return false;
    }
}
