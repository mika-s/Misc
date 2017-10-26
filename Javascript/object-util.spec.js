// Testing with Mocha as test runner and should for assertions.

describe('objectIsEmpty should return true', function () {
  it('when the object is empty', function () {
    let object = { }
    let result = objectIsEmpty(object)
    result.should.be.true()
  })
})

describe('objectIsEmpty should return false', function () {
  it('when the object is not empty', function () {
    let object = { a: 'test' }
    let result = objectIsEmpty(object)
    result.should.be.false()
  })
})