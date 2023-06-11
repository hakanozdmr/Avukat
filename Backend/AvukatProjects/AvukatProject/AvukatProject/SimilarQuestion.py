

from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.metrics.pairwise import cosine_similarity
import json
import pyodbc
import sys

cnxn_str = ('DRIVER={ODBC Driver 17 for SQL Server};SERVER=DESKTOP-78I8UB5;DATABASE=AvukatProjects;Trusted_Connection=yes;')
cnxn = pyodbc.connect(cnxn_str)
cursor = cnxn.cursor()

# Veritabanındaki tüm verileri sorgulayın
cursor.execute('SELECT * FROM dbo.Questions')
rows = cursor.fetchall()
# Tüm verileri bir liste halinde depolayın
#print(rows[0][1])

documents = []
for row in rows:
    documents.append(row[1])
idDocuments = []
for row in rows:
    idDocuments.append(row[0])

# Tüm verileri TfidfVectorizer kullanarak vektöre dönüştürün
vectorizer = TfidfVectorizer()
vectors = vectorizer.fit_transform(documents)
# Vectorize the questions using TfidfVectorizer
# print(sys.argv[1])
s = sys.argv[1].strip('{}')
result = {}
for item in s.split(","):
    key_start = item.index(":") + 1
    key = item[:key_start - 1]
    value = item[key_start:]
    result[key] = value

#print(result['Question'])
question = result['Question']
# Replace keys without quotes with keys with double quotes

# Parse the modified string as JSON
# data = json.loads(s)

# print(data)
# print(data['Question'])
def find_similar_questions(question):
    # query = question["Question"]
    query = question
    query_vector = vectorizer.transform([query])
    similarities = cosine_similarity(query_vector, vectors)

    threshold = 0.1
    max_similarity = 0
    max_question_id = 0
    # similar_indexes = [i for i in range(len(similarities[0])) if similarities[0][i] > threshold]

    # Benzer soruları ve benzerlik oranlarını bir sözlükte depolayın
    similar_questions = {}
    for i in range(similarities.shape[1]):
        if similarities[0][i] > threshold:
            similar_questions[rows[i][0]] = similarities[0][i]

            if similarities[0][i] > max_similarity:
                max_similarity = similarities[0][i]
                max_question = documents[i]
                max_question_id = idDocuments[i]
    # Sonuçları JSON formatında döndürün
    result_objects = {"Question": question, "OppressionQuestionId": max_question_id, "Oppression": max_similarity}
    # return result_objects
    return print(result_objects)



# # Serialize and return the result
# question = {"id": 1,"Question": "Nasıl bir güzellik salonu bulabilirim?","SoruSayısı": 1}
# print(question["Question"])

# # find_similar_questions fonksiyonunu çağırarak benzer soruları bulma
similar_questions = find_similar_questions(question)

