# -*- coding: utf-8 -*-

def main():
    example_list = [1, 3, 3, 2, 4, 2]
    unique_values_list = remove_duplicates(example_list)

    print(example_list)
    print(unique_values_list)


def remove_duplicates(nonunique):
    """Remove duplicate values in a list.

        Args:
            nonunique (list) - a list of values

        Returns:
            a list of the unique values in the nonunique list

        Example:
            unique_values(['a', 'a', 'b', 'c']) --> ['a', 'b', 'c']
    """

    unique = sorted(set(nonunique), key=lambda x: nonunique.index(x))
    
    return unique


if __name__ == '__main__':
    main()
