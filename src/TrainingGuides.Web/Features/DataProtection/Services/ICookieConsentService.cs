﻿using TrainingGuides.Admin;
using TrainingGuides.Web.Helpers.Cookies;

namespace TrainingGuides.Web.Features.DataProtection.Services;
public interface ICookieConsentService
{
    bool CurrentContactIsVisitorOrHigher();
    CookieConsentLevel GetCurrentCookieConsentLevel();
    Task<CookieLevelConsentMappingInfo> GetCurrentMapping();
    Task<bool> SetCurrentCookieConsentLevel(CookieConsentLevel level, IDictionary<int, string> mapping);
    Task<bool> SetCurrentCookieConsentLevel(CookieConsentLevel level, IEnumerable<string> acceptAllList);
    bool UpdateCookieLevels(CookieConsentLevel level);
}
