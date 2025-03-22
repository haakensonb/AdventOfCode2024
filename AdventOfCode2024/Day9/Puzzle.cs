namespace AdventOfCode2024.Day9;

public class Puzzle
{
    private List<string> _expandedDiskMap;

    public Puzzle(string diskMapInput)
    {
        _expandedDiskMap = ExpandDiskMap(diskMapInput);
    }

    private List<string> ExpandDiskMap(string diskMap)
    {
        var expandedDiskMap = new List<string>();
        var idCounter = 0;
        for (var i = 0; i < diskMap.Length; i++)
        {
            var numOfChars = int.Parse(diskMap.Substring(i, 1));
            if (i % 2 == 0)
            {
                for (var j = 0; j < numOfChars; j++)
                {
                    expandedDiskMap.Add(idCounter.ToString());
                }

                idCounter += 1;
            }
            else
            {
                for (var j = 0; j < numOfChars; j++)
                {
                    expandedDiskMap.Add(".");
                }
            }
        }

        return expandedDiskMap;
    }

    public void MoveFileBlocks()
    {
        var startIdx = _expandedDiskMap.IndexOf(".");
        var endIdx = _expandedDiskMap.Count - 1;
        // Find first number starting from end of disk map
        while (_expandedDiskMap[endIdx].Equals("."))
        {
            endIdx -= 1;
        }

        // Move valid values from endIdx to startIdx until indexes overlap
        while (startIdx < endIdx)
        {
            while (!_expandedDiskMap[startIdx].Equals("."))
            {
                startIdx += 1;
            }

            while (_expandedDiskMap[endIdx].Equals("."))
            {
                endIdx -= 1;
            }

            // Need to check indexes again
            if (startIdx < endIdx)
            {
                _expandedDiskMap[startIdx] = _expandedDiskMap[endIdx];
                _expandedDiskMap[endIdx] = ".";
                startIdx += 1;
                endIdx -= 1;
            }
        }
    }

    // This is so gross
    public void MoveFileBlocksWithoutFrag()
    {
        // Find rightmost starting id
        var fileEndIdx = _expandedDiskMap.Count - 1;
        while (_expandedDiskMap[fileEndIdx].Equals("."))
        {
            fileEndIdx -= 1;
        }

        var currentId = int.Parse(_expandedDiskMap[fileEndIdx]);
        // Find the size of the current id block
        var fileStartIdx = fileEndIdx;
        while (fileStartIdx > 0 && _expandedDiskMap[fileStartIdx].Equals(currentId.ToString()))
        {
            fileStartIdx -= 1;
        }

        var fileBlockSize = fileEndIdx - fileStartIdx;
        // Move current id block
        while (currentId >= 0)
        {
            // Find first open space
            var spaceStartIdx = 0;
            while (!_expandedDiskMap[spaceStartIdx].Equals("."))
            {
                spaceStartIdx += 1;
            }

            var spaceEndIdx = spaceStartIdx;
            while (_expandedDiskMap[spaceEndIdx].Equals("."))
            {
                spaceEndIdx += 1;
            }

            var spaceSize = spaceEndIdx - spaceStartIdx;

            // Keep moving through open spaces if the file won't fit
            while (fileBlockSize > spaceSize && spaceEndIdx < fileStartIdx)
            {
                while (!_expandedDiskMap[spaceStartIdx].Equals("."))
                {
                    spaceStartIdx += 1;
                }

                spaceEndIdx = spaceStartIdx;
                while (_expandedDiskMap[spaceEndIdx].Equals("."))
                {
                    spaceEndIdx += 1;
                }

                spaceSize = spaceEndIdx - spaceStartIdx;
                if (spaceSize < fileBlockSize)
                {
                    spaceStartIdx = spaceEndIdx;
                }
            }

            if (fileBlockSize <= spaceSize && spaceStartIdx < fileStartIdx)
            {
                // Write file over space
                for (var i = spaceStartIdx; i < spaceStartIdx + fileBlockSize; i++)
                {
                    _expandedDiskMap[i] = currentId.ToString();
                }

                // Clear original file location
                for (var i = fileStartIdx + 1; i < fileEndIdx + 1; i++)
                {
                    _expandedDiskMap[i] = ".";
                }
            }

            // Move to next file block
            currentId -= 1;
            // Find rightmost starting id
            fileEndIdx = _expandedDiskMap.LastIndexOf(currentId.ToString());
            // Find the size of the current id block
            fileStartIdx = fileEndIdx;
            while (fileStartIdx > 0 && _expandedDiskMap[fileStartIdx].Equals(currentId.ToString()))
            {
                fileStartIdx -= 1;
            }

            fileBlockSize = fileEndIdx - fileStartIdx;
        }
    }

    public long Checksum()
    {
        long result = 0;
        for (var i = 0; i < _expandedDiskMap.Count; i++)
        {
            if (!_expandedDiskMap[i].Equals("."))
            {
                var val = int.Parse(_expandedDiskMap[i]);
                result += (val * i);
            }
        }

        return result;
    }
}