for i in {1..15}
do
  curl -X POST http://localhost:5247/api/landing/create-new \
    -H "Content-Type: application/json" \
    -d "{\"data\": \"Test Data $i\", \"quantity\": 15}"
  echo ""
done
