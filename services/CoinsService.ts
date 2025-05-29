type PricePoint = [number, number];

export async function getData(coin: string): Promise<PricePoint[]> {
  const url = `https://api.coingecko.com/api/v3/coins/${coin}/market_chart?vs_currency=usd&days=1`;

  try {
    const response = await fetch(url);
    if (!response.ok) {
      throw new Error(`HTTP error ${response.status}`);
    }

    const data: { prices: PricePoint[] } = await response.json();
    return data.prices; // ✅ retourne le tableau [timestamp, prix]

  } catch (error: unknown) {
    if (error instanceof Error) {
      console.error("Erreur:", error.message);
    } else {
      console.error("Erreur inconnue", error);
    }
    return []; // ✅ en cas d'erreur, retourner un tableau vide
  }
}
