// Testing with Mocha as test runner and chai for assertions.

describe('randomRgbaString()', function () {
  describe('should return an rbga string when', function () {
    it('the function is called with correct parameters', function () {
      let rgbaString = randomRgbaString(0.7)
      let rgbaRegexp = /^rgba\(\d+,\d+,\d+,\d\.\d+\)$/
      chai.expect(rgbaRegexp.test(rgbaString)).equal(true)
    })
  })
})

describe('randomHslaString()', function () {
  describe('should return a hsla string when', function () {
    it('the function is called with correct parameters', function () {
      let hslaString = randomHslaString(90, 60, 0.7)
      let hslaRegexp = /^hsla\(\d+,\d+%,\d+%,\d\.\d+\)$/
      chai.expect(hslaRegexp.test(hslaString)).equal(true)
    })
  })
})