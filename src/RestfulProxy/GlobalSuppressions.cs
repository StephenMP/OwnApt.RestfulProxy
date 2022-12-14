// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CC0022:Should dispose object", Justification = "Gets disposed later when disposing HttpClient", Scope = "member", Target = "~P:OwnApt.RestfulProxy.Domain.Invokers.Invoker.HttpClient")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CC0022:Should dispose object", Justification = "Gets disposed later when disposing HttpClient", Scope = "member", Target = "~M:OwnApt.RestfulProxy.Domain.HttpClientFactory.Create(System.Net.Http.DelegatingHandler[])~System.Net.Http.HttpClient")]

