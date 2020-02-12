import os
from xml import sax

from app.const import const
from app.data.nameditem import NamedItem
from app.exceptions import FinishedException


class ZhongYao(NamedItem):
    pass


class _zhongyao(sax.ContentHandler):
    def __init__(self):
        self.name = ""
        self.pinyin = ""
  
    def startElement(self, name, attrs):
        if name == "名称":
            self.name = attrs["hz"]
            self.pinyin = attrs["py"]
            raise FinishedException()


def load_zhongyaos():
    """（程序启动时）加载中药信息，返回类型为ZhongYao的列表"""
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
