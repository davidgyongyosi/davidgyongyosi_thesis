return {
  // 'jest' or 'karma'. The default is jest. 
  // This value determines how function mock and assert is to be done.
  framework: 'karma',

  // Your component may use directives and pipes, which are defined in app-level.
  // Because your test does not know app-level declarations, they may break your test.
  // Your unit test should declare them separately as mock objects
  requiredComponentTestDeclarations: { 
    directives: [ 'myCustom' ], 
    pipes: [ 'translate', 'phoneNumber', 'safeHtml' ],
  },

  // Your constructor may use injectable services, that may only work in certain environment
  // Because your test does not know the specific environment, they may break your test
  // The follow object will tell test generator to mock those services with your own code
  // e.g. @Injectable() MockElementRef { nativeElement = {}; }
  providerMocks: {
    ElementRef: `nativeElement = {};`,
    Router: `navigate() {};`,
    Document: `querySelector() {};`,
    HttpClient: `post() {};`,
    TranslateService: `translate() {};`,
    EncryptionService: []
  }
}