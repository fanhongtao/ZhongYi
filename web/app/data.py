import os
from app.const import const
from xml import sax

class Data:
  def __init__(self):
    self.zhongyaos = loadZhongYaos()

def loadZhongYaos():
  result = []
  list = os.listdir(const.ZHONGYAO_PATH)
  for file in list:
    if (file.endswith(".xml")):
      parser = sax.make_parser()
      parser.setFeature(sax.handler.feature_namespaces, 0)
      zhongyao = _zhongyao()
      parser.setContentHandler(zhongyao)
      try:
        parser.parse(const.ZHONGYAO_PATH + file)
      except FinishedException:
        pass
      result.append(ZhongYao(zhongyao.name, zhongyao.pinyin))
  return result

def toAsciiPinyin(pinyin):
  asciiPy = pinyin.replace('ā', 'a');
  asciiPy = asciiPy.replace('á', 'a');
  asciiPy = asciiPy.replace('ǎ', 'a');
  asciiPy = asciiPy.replace('à', 'a');
  asciiPy = asciiPy.replace('ē', 'e');
  asciiPy = asciiPy.replace('é', 'e');
  asciiPy = asciiPy.replace('ě', 'e');
  asciiPy = asciiPy.replace('è', 'e');
  asciiPy = asciiPy.replace('ī', 'i');
  asciiPy = asciiPy.replace('í', 'i');
  asciiPy = asciiPy.replace('ǐ', 'i');
  asciiPy = asciiPy.replace('ì', 'i');
  asciiPy = asciiPy.replace('ō', 'o');
  asciiPy = asciiPy.replace('ó', 'o');
  asciiPy = asciiPy.replace('ǒ', 'o');
  asciiPy = asciiPy.replace('ò', 'o');
  asciiPy = asciiPy.replace('ū', 'u');
  asciiPy = asciiPy.replace('ú', 'u');
  asciiPy = asciiPy.replace('ǔ', 'u');
  asciiPy = asciiPy.replace('ù', 'u');
  asciiPy = asciiPy.replace('ǖ', 'v');
  asciiPy = asciiPy.replace('ǘ', 'v');
  asciiPy = asciiPy.replace('ǚ', 'v');
  asciiPy = asciiPy.replace('ǜ', 'v');
  asciiPy = asciiPy.replace('ü', 'v');
  return asciiPy

class ZhongYao:
  def __init__(self, name, pinyin):
    self.name = name
    self.pinyin = pinyin
    self.asciiPinyin = toAsciiPinyin(pinyin)
    
  def matchPinyin(self, input):
    ret = True
    start = 0
    for ch in input:
      idx = self.asciiPinyin.find(ch, start)
      if (idx == -1):
        ret = False
        break
      start = idx + 1
    return ret

  def matchHanzi(self, input):
    ret = True
    start = 0
    for ch in input:
      idx = self.name.find(ch, start)
      if (idx == -1):
        ret = False
        break
      start = idx + 1
    return ret

class FinishedException(BaseException):pass

class _zhongyao(sax.ContentHandler):
  def __init__(self):
    self.name = ""
    self.pinyin = ""
  
  def startElement(self, name, attrs):
    if name == "名称":
      self.name = attrs["hz"]
      self.pinyin = attrs["py"]
      raise FinishedException()
