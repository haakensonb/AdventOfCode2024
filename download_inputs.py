# Quick hacky script to download inputs

import os
import requests
import sys

data_dir = "./AdventOfCode2024/Data"
base_url = "https://adventofcode.com/2024/day/$DAY_NUM/input"


def create_dir(dir_path: str) -> None:
    if not os.path.exists(dir_path):
        os.makedirs(dir_path)


def download(url: str, session_token: str, output_path: str) -> None:
    print(f"Downloading... {url}")
    resp = requests.get(url, cookies={"session": session_token})
    with open(output_path, "w") as f:
        f.write(resp.text.strip())
        print(f"File written: {output_path}")


def main() -> None:
    args = sys.argv

    if (args[1] == "-h"):
        print("python download_inputs <final_day_num> <session_token>")
        return

    final_day = int(args[1])
    session_token = args[2]

    create_dir(data_dir)

    for i in range(1, final_day + 1):
        url = base_url.replace("$DAY_NUM", str(i))
        output_path = f"{data_dir}/input_{i}.txt"
        download(url, session_token, output_path)

if __name__ == "__main__":
    main()
