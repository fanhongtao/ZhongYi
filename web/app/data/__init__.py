import os
from xml.dom.minidom import parse

from app.data import zhongyao
from app.data import fangji
from app.const import const

class Data:
    def __init__(self):
        self.zhongyaos = zhongyao.load_zhongyaos()
        self.fangjis = fangji.load_fangjis()
        self._init_dirs()
        self._format_fangji()
    
    def _init_fufang_dict(self):
        dict = {}
        for fangji in self.fangjis:
            for fufang in fangji.fufangs:
                if fufang in dict:
                    list = dict[fufang]
                else:
                    list = []
                    dict[fufang] = list
                list.append(fangji.name)
        return dict
    
    def _init_dirs(self):
        os.makedirs(const.FANGJI_WORK_PATH, exist_ok=True)
    
    def _init_fufang_jianbie_dict(self):
        dict = {}
        for fangji in self.fangjis:
            for jianbie in fangji.jianbies:
                for fang in jianbie["fang"]:
                    if fangji.name == fang:
                        continue
                    if fang in dict:
                        list = dict[fang]
                    else:
                        list = []
                        dict[fang] = list
                    list.append(jianbie)
        return dict
    
    def _format_fangji(self):
        fufang_dict = self._init_fufang_dict()
        fangji_jianbie_dict = self._init_fufang_jianbie_dict()
        dir = const.FANGJI_PATH
        files = os.listdir(dir)
        for file in files:
            if (not file.endswith(".xml")) or (file == "template.xml"):
                continue
            dom = parse(dir + file)
            name = file[:-4]  # 删除 ".xml" 后缀
            if (name in fangji_jianbie_dict):
                list = fangji_jianbie_dict[name]
                for jianbie in list:
                    dom.documentElement.appendChild(jianbie["jianbie"].cloneNode(deep=True))
            
            if name in fufang_dict:
                list = fufang_dict[name]
                for zhufang in list:
                    dom.documentElement.appendChild(self._create_node(dom, "主方", zhufang))
            
            target = const.FANGJI_WORK_PATH + file
            with open(target, 'wb') as fp:
                fp.write(dom.toxml(encoding='utf-8'))

    def _create_node(self, dom, tag, data):
        node = dom.createElement(tag)
        node.appendChild(dom.createTextNode(data))
        return node
