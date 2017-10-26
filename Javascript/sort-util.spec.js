// Testing with Mocha as test runner and should for assertions.

describe('sortBy should return a sorted array', function () {
  it('when given an unsorted array of objects and a field - 1', function () {
    let array = [
      { a: 5, b: 'test5' },
      { a: 2, b: 'test2' },
      { a: 3, b: 'test3' },
      { a: 1, b: 'test1' },
      { a: 4, b: 'test4' }
    ]

    let sortedArray = sortBy(array, 'a')
    sortedArray.length.should.equal(array.length)
    sortedArray[0].a.should.equal(1)
    sortedArray[1].a.should.equal(2)
    sortedArray[2].a.should.equal(3)
    sortedArray[3].a.should.equal(4)
    sortedArray[4].a.should.equal(5)
  })

  it('when given an unsorted array of objects and a field - 2', function () {
    let array = [
      { a: 5, b: 'test5' },
      { a: 2, b: 'test2' },
      { a: 2, b: 'test3' },
      { a: 1, b: 'test1' },
      { a: 4, b: 'test4' }
    ]

    let sortedArray = sortBy(array, 'a')
    sortedArray.length.should.equal(array.length)
    sortedArray[0].a.should.equal(1)
    sortedArray[1].a.should.equal(2)
    sortedArray[2].a.should.equal(2)
    sortedArray[3].a.should.equal(4)
    sortedArray[4].a.should.equal(5)
  })
})
