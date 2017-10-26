/* eslint-env mocha */

describe('some-service', function () {
  beforeEach(angular.mock.module('app'))

  var someService
  var $log // eslint-disable-line

  beforeEach(angular.mock.inject(function (_someService_, _$log_) {
    someService = _someService_
    $log = _$log_
  }))

  describe('function1()', function () {
    describe('should return X when', function () {
      it('this and that is assumed and done', function () {
        let abc = 1
        let qwerty = 2
        let result = someService.function1(abc, qwerty)
        chai.expect(result).equal(true)
      })
      
      it('that and this is assumed and done', function () {
        let abc = 2
        let qwerty = 1
        let result = someService.function1(abc, qwerty)
        chai.expect(result).equal(true)
      })
    })
  })

  describe('function2()', function () {
    describe('should return Y when', function () {
      it('this and that is assumed and done', function () {
        let testvar = 3
        let arg2 = 4
        let result = someService.function2(testvar, arg2)
        chai.expect(typeof result).equal('undefined')
      })
    })
  })
})
