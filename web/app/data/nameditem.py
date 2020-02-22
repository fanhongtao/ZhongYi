import os
from xml import sax

from app.exceptions import FinishedException


class NamedItem(sax.ContentHandler):
    """有名字、拼音的项目，用于根据汉字或拼音进行查询"""
    def __init__(self):
        self.name = ""
        self.pinyin = ""
        self.asciiPinyin = ""
    
    def startElement(self, name, attrs):
        if name == "名称":
            self.set_name(attrs["hz"], attrs["py"])
            raise FinishedException()
    
    def set_name(self, name, pinyin):
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


def load_list(dir, item_class):
    result = []
    list = os.listdir(dir)
    for file in list:
        if (file.endswith(".xml")):
            parser = sax.make_parser()
            parser.setFeature(sax.handler.feature_namespaces, 0)
            item = item_class()
            parser.setContentHandler(item)
            try:
                parser.parse(dir + file)
            except FinishedException:
                pass
            result.append(item)
    result.sort(key=lambda x: x.asciiPinyin)
    return result
