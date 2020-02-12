class NamedItem:
    """有名字、拼音的项目，用于根据汉字或拼音进行查询"""
    def __init__(self, name, pinyin):
      self.name = name
      self.pinyin = pinyin
      self.asciiPinyin = get_ascii_pinyin(pinyin)
  
    def match(self, input, byPinyin):
        """记录的名字是否能匹配输入的字符串
        
        :param input: 待匹配的字符串
        :param byPinyin: 是否是以拼音方式进行匹配
        """
        if (byPinyin):
            target = self.asciiPinyin
        else:
            target = self.name
        ret = True
        start = 0
        for ch in input:
            idx = target.find(ch, start)
            if (idx == -1):
                ret = False
                break
            start = idx + 1
        return ret


def get_ascii_pinyin(pinyin):
    """将带有声调的拼音，转换成没有声调的形式"""
    asciiPy = pinyin.replace('ā', 'a')
    asciiPy = asciiPy.replace('á', 'a')
    asciiPy = asciiPy.replace('ǎ', 'a')
    asciiPy = asciiPy.replace('à', 'a')
    asciiPy = asciiPy.replace('ē', 'e')
    asciiPy = asciiPy.replace('é', 'e')
    asciiPy = asciiPy.replace('ě', 'e')
    asciiPy = asciiPy.replace('è', 'e')
    asciiPy = asciiPy.replace('ī', 'i')
    asciiPy = asciiPy.replace('í', 'i')
    asciiPy = asciiPy.replace('ǐ', 'i')
    asciiPy = asciiPy.replace('ì', 'i')
    asciiPy = asciiPy.replace('ō', 'o')
    asciiPy = asciiPy.replace('ó', 'o')
    asciiPy = asciiPy.replace('ǒ', 'o')
    asciiPy = asciiPy.replace('ò', 'o')
    asciiPy = asciiPy.replace('ū', 'u')
    asciiPy = asciiPy.replace('ú', 'u')
    asciiPy = asciiPy.replace('ǔ', 'u')
    asciiPy = asciiPy.replace('ù', 'u')
    asciiPy = asciiPy.replace('ǖ', 'v')
    asciiPy = asciiPy.replace('ǘ', 'v')
    asciiPy = asciiPy.replace('ǚ', 'v')
    asciiPy = asciiPy.replace('ǜ', 'v')
    asciiPy = asciiPy.replace('ü', 'v')
    return asciiPy
