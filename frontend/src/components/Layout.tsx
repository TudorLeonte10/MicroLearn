import Navbar from "./Navbar";
import Footer from "./Footer";

export default function Layout({ children }: { children: React.ReactNode }) {
  return (
    <div className="min-h-screen bg-gray-100 flex flex-col">
      <Navbar />
      <main className="container mx-auto px-4 py-8 flex-grow">{children}</main>
      <Footer />
    </div>
  );
}
