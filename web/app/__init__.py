from flask import Flask

app = Flask(__name__)
app.config.from_object('config')

from app import data
app.data = data.Data()

from app import views
