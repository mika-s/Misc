# -*- coding: utf-8 -*-

"""Examples of JSON reading and writing."""

import json


def main():
    reading_writing_json_file()


def reading_writing_json_file():
    """Read all the titles in a JSON file and write them to a new JSON file."""

    with open("data\\jsonfile.json", encoding="utf8") as data_file:
        data = json.load(data_file)

    titles = []
    for kurs in data:
        for tittel in kurs["tittel"]:
            if tittel["spraak"] == "default":
                titles.append(tittel["verdi"])

    with open("data\\titles.json", "w", encoding="utf-8") as outfile:
        outfile.write(json.dumps(titles, sort_keys=True, indent=4))


if __name__ == '__main__':
    main()
