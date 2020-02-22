# ZhongYi
Project about Chinese Medicine.

不为良相，便为良医。

---

# 1 使用说明

以 Windows 操作系统为例进行说明。

## 1.1 安装 Python

从 [Python 官网](https://www.python.org/) 下载 Python 3 的新版本，如：[Python 3.8.1](https://www.python.org/ftp/python/3.8.1/python-3.8.1.exe)，运行安装包，即可完成安装。

## 1.2 安装 Flask

安装Python之后，再执行如下命令安装 [Flask](https://github.com/pallets/flask)

```python
pip3 install flask
```

国内用户安装时，可以使用阿里云镜像加速：

```python
pip3 install flask -i https://mirrors.aliyun.com/pypi/simple/
```

## 1.3 启动Web服务

进入 web 目录，然后使用以下命令启动：

```python
python3 run.py
```

## 1.4 访问

启动Web服务后，在浏览器中访问以下地址： 

```
localhost:5000/
```

即可看到服务的主界面
